using AutoclickerLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoclickerUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IKeyboardService keyboardService;
        private IMouseService mouseService;
        private bool capturedCursor = false;

        public MainWindow()
        {
            mouseService = new MouseService();
            keyboardService = new KeyboardService();
            keyboardService.Subscribe(GlobalKeydown);

            InitializeComponent();
        }

        /// <summary>
        /// Обработчик запуска автоматического кликания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartClick(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;
            capturedCursor = true;
            
            FirstClickerProgram();
        }

        /// <summary>
        /// Обработчик, очищающий экран
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearScreenClick(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "";
        }

        /// <summary>
        /// Обработчик события глобального нажатия клавиши клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalKeydown(object sender, KeyPressEventArgs e)
        {
            textBlock.Text += $"\n{(byte)e.KeyChar}";
            if (e.KeyChar != 113)
                return;
            textBlock.Text += $"\nAutoclicker stop";
            capturedCursor = false;
            startButton.IsEnabled = true;
        }

        private Task FirstClickerProgram()
        {
            return Task.Run(() =>
            {
                TextBlockWriteLine(textBlock, "For exit press key 'q', code 113");

                Timer(5);
                var startPoint = mouseService.GetCursorPosition();
                TextBlockWriteLine(textBlock, $"Start:\nX:{startPoint.X}\nY:{startPoint.Y}");

                Timer(5);
                var endPoint = mouseService.GetCursorPosition();
                TextBlockWriteLine(textBlock, $"End:\nX:{endPoint.X}\nY:{endPoint.Y}");

                var currentPoint = startPoint;
                mouseService.SetCursorPosotion(startPoint);

                while (capturedCursor)
                {
                    mouseService.DoLeftMouseClick();

                    currentPoint.X += 10;
                    mouseService.SetCursorPosotion(currentPoint);
                    if (currentPoint.X >= endPoint.X)
                        currentPoint = startPoint;

                    Thread.Sleep(20);
                }
            });
        }

        /// <summary>
        /// В другом потоке добавляет текст в TextBlock
        /// </summary>
        /// <param name="textBlock">Куда добавить текст</param>
        /// <param name="text">Текст, добавленный с новой строки</param>
        public void TextBlockWriteLine(TextBlock textBlock, string text)
        {
            Dispatcher.Invoke(
                (Action<TextBlock, string>)AddTextToTextBlock,
                System.Windows.Threading.DispatcherPriority.Normal,
                textBlock, text);
        }

        private void AddTextToTextBlock(TextBlock textBlock, string text)
        {
            textBlock.Text += Environment.NewLine + text;
        }

        private void Timer(int sec)
        {
            TextBlockWriteLine(textBlock, $"{sec}...");
            while (sec > 0)
            {
                Thread.Sleep(1000);
                TextBlockWriteLine(textBlock, $"{--sec}...");
            }
        }
    }
}

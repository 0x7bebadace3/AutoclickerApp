using AutoclickerLib.Services;
using System;
using System.Threading;

namespace AutoclickerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IMouseService mouseService = new MouseService();
            IKeyboardService keyboardService = new KeyboardService();
            //keyboardService.Subscribe();

            Timer(5);
            var startPoint = mouseService.GetCursorPosition();
            Console.WriteLine($"Start:\nX:{startPoint.X}\nY:{startPoint.Y}");
            Console.WriteLine();

            Timer(5);
            var endPoint = mouseService.GetCursorPosition();
            Console.WriteLine($"End:\nX:{endPoint.X}\nY:{endPoint.Y}");
            Console.WriteLine();

            var currentPoint = startPoint;
            mouseService.SetCursorPosotion(startPoint);

            //while (true)
            //{
            //    mouseService.DoLeftMouseClick();

            //    ++currentPoint.X;
            //    mouseService.SetCursorPosotion(currentPoint);
            //    if (currentPoint.X >= endPoint.X)
            //        break;

            //    Thread.Sleep(100);
            //}
            
            Console.WriteLine("For exit press any key...");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }

        private static void Timer(int sec)
        {
            Console.WriteLine($"{sec}...");
            while (sec > 0)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{--sec}...");
            }
            Console.WriteLine();
        }
    }
}

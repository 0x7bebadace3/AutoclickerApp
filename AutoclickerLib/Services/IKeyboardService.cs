using System.Windows.Forms;

namespace AutoclickerLib.Services
{
    public interface IKeyboardService
    {
        /// <summary>
        /// Добавляет обработчик глобального нажатия клавиши
        /// </summary>
        /// <param name="handler"></param>
        void Subscribe(KeyPressEventHandler handler);

        /// <summary>
        /// Снимает обработчик глобального нажатия клавиши
        /// </summary>
        /// <param name="handler"></param>
        void Unsubscribe(KeyPressEventHandler handler);
    }
}

using System.Windows;

namespace AutoclickerLib.Services
{
    public interface IMouseService
    {
        /// <summary>
        /// Возвращает позицию курсора
        /// </summary>
        /// <returns>Координату курсора</returns>
        Point GetCursorPosition();

        /// <summary>
        /// Устанавливает курсор в заданой позиции экрана
        /// </summary>
        /// <param name="position">Координата экрана</param>
        /// <returns>Успешно ли произошла смена позиции курсора</returns>
        bool SetCursorPosotion(Point position);

        /// <summary>
        /// Клик левой кнопкой мыши в текущем положении мыши
        /// </summary>
        void DoLeftMouseClick();
    }
}

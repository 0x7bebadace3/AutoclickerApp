using System.Runtime.InteropServices;
using System.Windows;
using AutoclickerLib.Models;

namespace AutoclickerLib.Services
{
    public class MouseService : IMouseService
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Point GetCursorPosition()
        {
            GetCursorPos(out POINT lpPoint);
            return lpPoint;
        }

        public bool SetCursorPosotion(Point position)
        {
            return SetCursorPos((int)position.X, (int)position.Y);
        }

        public void DoLeftMouseClick()
        {
            //MouseEvent(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            MouseEvent(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        [DllImport("user32.dll", EntryPoint = "GetCursorPos")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll", EntryPoint = "mouse_event")]
        private static extern void MouseEvent(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    }
}

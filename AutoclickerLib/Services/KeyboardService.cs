using Gma.System.MouseKeyHook;
using System;
using System.Windows.Forms;

namespace AutoclickerLib.Services
{
    public class KeyboardService : IKeyboardService, IDisposable
    {
        private IKeyboardMouseEvents globalHook;
        private bool disposed = false;

        public KeyboardService()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            globalHook = Hook.GlobalEvents();
        }

        public void Subscribe(KeyPressEventHandler handler)
        {
            globalHook.KeyPress += handler;
        }

        public void Unsubscribe(KeyPressEventHandler handler)
        {
            globalHook.KeyPress -= handler;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        ~KeyboardService()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                }

                // освобождаем неуправляемые объекты
                disposed = true;
                globalHook.Dispose();
            }
        }
    }
}

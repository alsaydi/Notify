using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Notify
{
    [Obsolete("don't use",true)]
    public class ListernerTaskIcon : TaskbarIcon
    {
        const int WM_HOTKEY = 0x0312;
        const int VK_CAPITAL = 0x14;
        const int MOD_CONTROL = 0x0002;
        const int MOD_NOREPEAT = 0x4000;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, ref int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static int _hotKeyId = 0;

        private IntPtr _windowHandle = IntPtr.Zero;

        public override void BeginInit()
        {
            base.BeginInit();

            HwndSource source = PresentationSource.FromDependencyObject(this) as HwndSource;
            source.AddHook(WndProc);
            RegisterShortcut(source.Handle);
        }

        private void RegisterShortcut(IntPtr handle)
        {
            if (RegisterHotKey(handle, ref _hotKeyId, MOD_NOREPEAT, VK_CAPITAL))
            {
                _windowHandle = handle;
            }
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //Debug.WriteLine("{0:x}", msg);
            if (msg == WM_HOTKEY)
            {
                var workWindow = new WorkWindow();
                workWindow.DataContext = new WorkWindowViewModel { SelectedText = (new TextSelectionReader()).TryGetSelectedTextFromActiveControl() };
                workWindow.Show();
            }
            return IntPtr.Zero;
        }
    }
}

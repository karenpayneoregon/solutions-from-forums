using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DisableScreenSaverCore.Classes;
internal class Operations
{
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    [DllImport("user32.dll")]
    private static extern bool SystemParametersInfo(int uAction, int uParam, ref int lpvParam, int flags);

    private const string RegistryAutoRunName = "DisableScreensaver";
    private const string RegistryKey = @"SOFTWARE\DisableScreensaver\";
    private const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

    private static void PressScrollLock()
    {
        const byte vkScroll = 0x91;
        const byte keyEventKeyup = 0x2;

        keybd_event(vkScroll, 0x45, 0, (UIntPtr)0);
        keybd_event(vkScroll, 0x45, keyEventKeyup, (UIntPtr)0);
    }
    public static int GetScreenSaverTimeout()
    {
        int value = 0;
        SystemParametersInfo(14, 0, ref value, 0);
        return value;
    }

    public static void Execute()
    {
        PressScrollLock();
        Thread.Sleep(300);
        PressScrollLock();
    }

    public static int TimeOut => (GetScreenSaverTimeout() - 1) * 999;
}

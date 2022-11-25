using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace BasicSqlServerPasswordApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
    }
}

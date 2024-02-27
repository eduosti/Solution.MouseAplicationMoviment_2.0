using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("User32.dll")]
    private static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    static void Main()
    {
        Console.WriteLine("Movendo o cursor do mouse a cada 5 segundos...");

        while (true)
        {
            // Gera posições aleatórias para X e Y
            var random = new Random();
            int x = random.Next(0, Console.WindowWidth);
            int y = random.Next(0, Console.WindowHeight);

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);

            // Move o cursor do mouse para a posição (x, y)
            //SetCursorPos(x + 1, y + 1);
            while ((x < 1000) & (y < 1000))
            {
                SetCursorPos(x, y);
                x = y + 1;
                y = x + 1;
                Console.WriteLine(x + " - " + y);
                Thread.Sleep(15);
            }

            while ((x > 0) & (y > 0))
            {
                SetCursorPos(x, y);
                x = y - 1;
                y = x - 1;
                Console.WriteLine(x + " - " + y);
                Thread.Sleep(15);
            }

        }
    }
}

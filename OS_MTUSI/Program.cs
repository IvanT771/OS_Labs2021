using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OS_MTUSI
{
    class Program
    {
        public static class Laba1
        {
            #region "Структуры"
            [StructLayout(LayoutKind.Sequential)]
            private struct SYSTEMTIME
            {
                [MarshalAs(UnmanagedType.U2)] public short Year;
                [MarshalAs(UnmanagedType.U2)] public short Month;
                [MarshalAs(UnmanagedType.U2)] public short DayOfWeek;
                [MarshalAs(UnmanagedType.U2)] public short Day;
                [MarshalAs(UnmanagedType.U2)] public short Hour;
                [MarshalAs(UnmanagedType.U2)] public short Minute;
                [MarshalAs(UnmanagedType.U2)] public short Second;
                [MarshalAs(UnmanagedType.U2)] public short Milliseconds;

                public SYSTEMTIME(DateTime dt)
                {
                    dt = dt.ToUniversalTime();  // SetSystemTime expects the SYSTEMTIME in UTC
                    Year = (short)dt.Year;
                    Month = (short)dt.Month;
                    DayOfWeek = (short)dt.DayOfWeek;
                    Day = (short)dt.Day;
                    Hour = (short)dt.Hour;
                    Minute = (short)dt.Minute;
                    Second = (short)dt.Second;
                    Milliseconds = (short)dt.Millisecond;
                }
            }
            #endregion

            #region "Мотоды внешней реализации"

            [DllImport("Kernel32", CharSet = CharSet.Auto)]
            public static extern bool GetComputerName(StringBuilder buffer, ref uint size);

            [DllImport("advapi32.dll", SetLastError = true)]
            static extern bool GetUserName(StringBuilder sb, ref uint length);

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern uint GetWindowsDirectory(StringBuilder lpBuffer, uint uSize);

            [DllImport("kernel32.dll")]
            static extern void GetLocalTime(out SYSTEMTIME lpSystemTime);

            #endregion

            //Вывод имени компьютера и пользователя.
            private static void T1()
            {
                uint size = 200;
                StringBuilder buffer = new StringBuilder(256);

                GetComputerName(buffer,ref size);
                Console.WriteLine("Computer name: "+buffer);

                GetUserName(buffer,ref size);
                Console.WriteLine("User name: "+buffer);
            }

            //Получение пути к дериктории windows.
            private static void T2()
            {
                uint size = 260;
                StringBuilder buffer = new StringBuilder(256);

                GetWindowsDirectory(buffer,size);
                Console.WriteLine("Window directory: "+buffer);
            }

            //Получение местного времени
            private static void T3()
            {
                SYSTEMTIME sysTime = new SYSTEMTIME();

                GetLocalTime(out sysTime);
                Console.WriteLine($"Текущее время: {sysTime.Hour}:{sysTime.Minute}:{sysTime.Second}");
            }
            
            //Исполнение всех подзадач
            public static void PrintTasks()
            {
                //T1();
                T2();
                T3();
            }
        }
       
        static void Main(string[] args)
        {
            Laba1.PrintTasks();
            Console.Read();
        }
    }
}

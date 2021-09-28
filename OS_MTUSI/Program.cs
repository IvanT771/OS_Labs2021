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
            [DllImport("Kernel32", CharSet = CharSet.Auto)]
            public static extern bool GetComputerName(StringBuilder buffer, ref uint size);

            [DllImport("advapi32.dll", SetLastError = true)]
            static extern bool GetUserName(StringBuilder sb, ref uint length);

            //Вывод имени компьютера и пользователя;
            private static void T1()
            {
                uint size = 200;
                StringBuilder buffer = new StringBuilder(256);

                GetComputerName(buffer,ref size);
                Console.WriteLine("Computer name: "+buffer);

                GetUserName(buffer,ref size);
                Console.WriteLine("User name: "+buffer);
            }

            //Исполнение всех подзадач
            public static void PrintTasks()
            {
                T1();
            }
        }
       
        static void Main(string[] args)
        {
            Laba1.PrintTasks();
            Console.Read();
        }
    }
}

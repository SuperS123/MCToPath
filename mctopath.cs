using System;
using System.Diagnostics;
using System.Security.Principal;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            if (!isElevated)
            {
                Console.WriteLine("Process must be ran as administrator to edit.\nDon't worry, source is available at https://github.com/SuperS123/MCToPath");
                Console.ReadLine();
            } else
            {
                Console.Title = "PATH Setter";
                Console.WriteLine("Adding %minecraft% as variable");
                System.Threading.Thread.Sleep(3000);
                var name = "minecraft";
                var scope = EnvironmentVariableTarget.User;
                var newValue  = "%APPDATA%\\.minecraft";
                Environment.SetEnvironmentVariable(name, newValue, scope);
                Console.WriteLine("Completed Task!");
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Restarting Computer to apply changes");
                System.Threading.Thread.Sleep(3000);
                System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
            }
        }
    }
}
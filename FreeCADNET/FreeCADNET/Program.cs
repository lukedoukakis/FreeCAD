using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FreeCADNET
{   
    class Program
    {
        [DllImport("../FreeCADApp.dll")]
        public static extern void Application_init(int argc, string[] argv);

        [DllImport("../FreeCADApp.dll")]
        public static extern void Application_run();

        [DllImport("../FreeCADApp.dll")]
        public static extern void Application_closeAllDocuments();

        static void Main(string[] args)
        {
            const string sBanner = "(C) BIG NOSES INC. (2020-2021)";

            // Initialization phase. =======================================================
            try
            {
                string[] fakeArgs = { "../FreeCADMainCmd.dll" };
                Application_init(fakeArgs.Length, fakeArgs);
            }
            catch (AccessViolationException e)
            {
                Console.WriteLine("WOOT");
            }
            catch (Exception e)
            {
                string appName = "boi"; //config["ExeName"];
                string msg = "";
                msg += $"Unknown runtime error occurred while initializating {appName}.\n\n";
                msg += $"Please contact the application's support team for more information.\n\n";
                Console.Write($"Initialization of {appName} failed:\n{msg}");
                System.Environment.Exit(101);
            }

            // Run phase. =================================================
            try
            {
                Application_run();
            }
            catch (Exception e)
            {
                Console.Write("oops i made an owwie ):");
            }

            // Destruction phase. =============================================
            try
            {
                Application_closeAllDocuments();
            }
            catch (Exception e)
            {
                Console.WriteLine("uhhhhhhhhhhhhhh");
            }
        }
    }
}

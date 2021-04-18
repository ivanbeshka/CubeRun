using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using CubeRun.Model;

namespace CubeRun
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            AttachConsole(-1);
            var map = new Map(".........................................\n" +
                              "                                         \n" +
                              ".........................................\n");
            
            map.WriteMap();
        }
        
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
    }
}
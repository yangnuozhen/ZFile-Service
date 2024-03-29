﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ZFile
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                if (args.Length == 0)
                {
                    Service1 service1 = new Service1();
                    service1.TestStartupAndStop(args);
                }
                string FirstArg = args[0];
                if (FirstArg == "-i")
                {
                    ProjectInstaller.InstallService();
                }
                if (FirstArg == "-u")
                {
                    ProjectInstaller.UninstallService();
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}

using DevelopersInformationSystem.Infrastructure.Repositories;
using System;

namespace DevelopersInformationSystem.Application
{
    public class StartUp
    {
        public static readonly DevInfoSysRepository _devInfoSys = new();
        static void Main()
        {
            var exitProcedure = false;
            while (!exitProcedure)
            {
                exitProcedure = _devInfoSys.MainWindow();
            }
        }
    }
}

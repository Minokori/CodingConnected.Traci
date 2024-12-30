using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET.Services;
internal class SumoProcessService : IProcessService
    {
    const int DEFAULTNUMRETRIES = 60;
    //copy logic from Python Traci API
    public Process GetProcess(string sumoCfgFile, int remotePort, bool useSumoGui = true, bool quitOnEnd = true, bool redirectOutputToConsole = false)
        {
        int numRetries = DEFAULTNUMRETRIES;
        while (numRetries > 0)
            {

            }

        return null;
        }


    }

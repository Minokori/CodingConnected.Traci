﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET.Services;
internal class SumoProcessService : IResponseService
    {
    public Process GetProcess(string sumoCfgFile, int remotePort, bool useSumoGui = true, bool quitOnEnd = true, bool redirectOutputToConsole = false) => throw new NotImplementedException();
    }

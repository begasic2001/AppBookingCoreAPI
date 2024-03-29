﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService
{
    public interface ILoggerService
    {
        void LogError(string message);  
        void LogWarning(string message);
        void LogInfo(string message);
        void LogDebug(string message);
    }
}

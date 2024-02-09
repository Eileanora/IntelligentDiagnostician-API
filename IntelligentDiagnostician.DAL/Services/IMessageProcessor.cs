﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentDiagnostician.DAL.Services;

public interface IMessageProcessor
{
    Task ProcessMessage(string topic, string payload);
}
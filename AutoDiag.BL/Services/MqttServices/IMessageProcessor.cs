﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDiag.BL.Services.MqttServices;

public interface IMessageProcessor
{
    Task ProcessMessage(string topic, Dictionary<string, string> payload);
}
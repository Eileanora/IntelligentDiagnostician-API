﻿using IntelligentDiagnostics.DataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace IntelligentDiagnostics.DAL.Services
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public MessageProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ProcessMessage(string topic, string payload)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Parse the JSON payload
                var message = JsonConvert.DeserializeObject<Dictionary<string, string>>(payload);

                // Check if it's a record or an error
                if (message != null && message.ContainsKey("system"))
                {
                    // <----------- add a check to check if message contents are valid here ------------->
                    foreach (var parameter in message.Keys)
                    {
                        if (parameter == "system")
                            continue;
                        // Create a new Record
                        var record = new Reading
                        {
                            ReadingValue = int.Parse(message[parameter]),
                            UserId = int.Parse(topic),
                            SystemCarId = int.Parse(message["system"]),
                            ParameterId = int.Parse(parameter),
                            ReadingDateTime = DateTime.UtcNow
                        };
                        dbContext.Add(record);
                    }
                }
                else if (message != null && message.ContainsKey("error"))
                {
                    // Create a new Error
                    var error = new Error
                    {
                        Description = message["value"],
                        UserId = int.Parse(topic),
                        ErrorDateTime = DateTime.UtcNow
                    };

                    dbContext.Add(error);
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
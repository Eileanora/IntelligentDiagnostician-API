﻿using System.Text;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace IntelligentDiagnostician.BL.Services.MqttServices;

public class MqttService : IMqttService
{
    private readonly IMqttClient _mqttClient;
    private readonly IMessageProcessor _messageProcessor;

    public MqttService(IMqttClient mqttClient, IMessageProcessor messageProcessor)
    {
        _mqttClient = mqttClient;
        _messageProcessor = messageProcessor;
    }

    public async Task ConnectAsync()
    {
        var options = new MqttClientOptionsBuilder()
            .WithClientId("Client1")
            .WithTcpServer("ba56550c63b34369a905b1bf7dfcb61f.s2.eu.hivemq.cloud", 8883)
            .WithTls(new MqttClientOptionsBuilderTlsParameters
            {
                UseTls = true,
                IgnoreCertificateChainErrors = true,
                IgnoreCertificateRevocationErrors = true,
                AllowUntrustedCertificates = true
            })
            .WithCredentials("ahmedsamir4299", "01060402354aA")
            .WithCleanSession()
            .Build();
        Console.WriteLine("WENT THROUGH CONNECTING");

        _mqttClient.UseConnectedHandler(async e =>
        {
            Console.WriteLine("### CONNECTED WITH SERVER ###");
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("#").Build());
        });

        _mqttClient.UseApplicationMessageReceivedHandler(async e =>
        {
            // Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
            // Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
            // Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            // Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
            // Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
            // Console.WriteLine();
            await _messageProcessor.ProcessMessage(e.ApplicationMessage.Topic, Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        });

        await _mqttClient.ConnectAsync(options);
    }

    public async Task DisconnectAsync()
    {
        await _mqttClient.DisconnectAsync();
    }
}
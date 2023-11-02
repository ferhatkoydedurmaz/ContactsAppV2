using Azure.Messaging.ServiceBus;
using ContactsApp.QueueService.QueueService;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace ContactsApp.QueueService.QueueService.ServiceBus;
public class QueueServiceHelper : IQueueServiceHelper
{
    private const string _queueServiceConnStr =
    "Endpoint=sb://queueservice.servicebus.windows.net/;SharedAccessKeyName=SharedAccessKey;SharedAccessKey=wHtVV+Pxs1vWkHzfdKU3u9y3DRIjfQkLo+ASbOIk3YI=";
    private readonly IConfiguration _configuration;

    public QueueServiceHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //Queue message gönderimi
    public async Task<bool> SendQueueMessage<T>(string queueName, T data)
    {
        var client = new ServiceBusClient(_queueServiceConnStr);

        ServiceBusSender sender = client.CreateSender(queueName);

        var response = await SendMessage(sender, data);

        return response;
    }

    #region Private Methods
    private static async Task<bool> SendMessage<T>(ServiceBusSender sender, T data)
    {
        string json = JsonSerializer.Serialize(data);

        byte[] messageArr = Encoding.UTF8.GetBytes(json);

        ServiceBusMessage message = new(messageArr);

        await sender.SendMessageAsync(message);

        return true;
    }
    #endregion

}

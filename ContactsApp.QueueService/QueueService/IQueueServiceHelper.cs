namespace ContactsApp.QueueService.QueueService;
public interface IQueueServiceHelper
{
    Task<bool> SendQueueMessage<T>(string queueName, T data);
}

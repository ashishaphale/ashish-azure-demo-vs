using ashish_storageacc_demo.Models;
using Azure.Storage.Queues;
using Newtonsoft.Json;
using System.Net.Mail;

namespace ashish_storageacc_demo.Services
{
    public class QueueService: IQueueService
    {
        private readonly IConfiguration _configuration;
        private readonly QueueClient _queueClient;
        //private string queueName = "attendee-emails";

        public QueueService(IConfiguration configuration, QueueClient queueClient)
        {
            this._configuration = configuration;
            _queueClient = queueClient; 
        }

        public async Task SendMessage(EmailMessage emailMessage)
        {
            //var queueClient = new QueueClient(_configuration["StorageConnectionString"],
            //    queueName,
            //    new QueueClientOptions
            //    {
            //        MessageEncoding = QueueMessageEncoding.Base64
            //    });

            await _queueClient.CreateIfNotExistsAsync();

            var message = JsonConvert.SerializeObject(emailMessage);

            await _queueClient.SendMessageAsync(message);
        }
    }
}

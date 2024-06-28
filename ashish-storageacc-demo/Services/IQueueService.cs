using ashish_storageacc_demo.Models;
using System.Net.Mail;

namespace ashish_storageacc_demo.Services
{
    public interface IQueueService
    {
        Task SendMessage(EmailMessage emailMessage);
    }
}

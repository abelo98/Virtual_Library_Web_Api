using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmail(string fromAddress,
            string destinationAddress, string subject, string textMesagge)
        {
            await Task.CompletedTask;
        }
    }
}

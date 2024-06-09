using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp12
{
    public class Message
    {
        public DateTime TimeStamp { get; set; }
        public string MessageText { get; set; }

        public Message(DateTime timeStamp, string messageText)
        {
            TimeStamp = timeStamp;
            MessageText = messageText;
        }
    }
}
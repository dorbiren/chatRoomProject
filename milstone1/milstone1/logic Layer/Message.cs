using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;

namespace milstone1.logic_Layer
{
    class Message : IMessage
    {
        private User user;

        public Guid Id { get; }

        public string UserName { get { return user.NickName; } }

        public DateTime Date { get; }

        public string MessageContent { get; }

        public string GroupID
        {
            get { return user.Group_Id; }
        }

        public Message (User user, Guid id, DateTime date, string messageContent)
        {
            this.user = user;
            this.Id = id;
            this.Date = date;
            this.MessageContent = messageContent;
        }

        private Boolean checkValidity (string body)
        {
            return true;
        }
        public void editBody (string newBody)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;

namespace milstone1.logic_Layer
{
   public  class Message : IMessage
    {
        private User user;

        public Guid Id { get; }

        public string UserName { get { return user.GetNickname(); } }

        public DateTime Date { get; }

        public string MessageContent { get; }

        public string GroupID
        {
            get { return user.GetGroup_Id(); }
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
            if (body.Length > 150) return false;
            else return true;
        }
        public void editBody (string newBody)
        {
            //this.MessageContent=newBody;
        }
        public string ToString()
        {
            return this.user + "," + this.Id + "," + this.UserName + "," + this.Date + "," + this.MessageContent + "," + this.GroupID;
        }
    }
}

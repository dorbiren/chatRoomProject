using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;

namespace milstone1.logic_Layer
{
    [Serializable]
    public class Message : IMessage
    {

        public Guid Id { get; }

        public string UserName { get; set; }

        public DateTime Date { get; }

        public string MessageContent { get; }

        public string GroupID { get; set; }


        public Message(IMessage msg)
        {
            //this.user = user;
            this.Id = msg.Id;
            this.Date = msg.Date;
            this.MessageContent = msg.MessageContent;
            this.UserName = msg.UserName;
            this.GroupID = msg.GroupID;
        }

        private Boolean checkValidity(string body)
        {
            if (body.Length > 150) return false;
            else return true;
        }
        public void editBody(string newBody)
        {
            //this.MessageContent=newBody;
        }
        public string ToString()
        {
            string final= this.Id + "@" + this.UserName + "@" + this.GroupID + "@" + this.Date + "@" + this.MessageContent + "@";
            final = final.Replace("@", System.Environment.NewLine);
            return final;
            

        }

    }
}
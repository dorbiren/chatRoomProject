using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;

namespace milstone1.logic_Layer
{
    public class User 
    {
        private string NickName { get; }
        private string Group_Id { get; }

        private User(string nickname, string group_id)
        {
            this.Group_Id = group_id;
            this.NickName = nickname;
        }

        private static bool isValid(string nickname, string group_id)
        {
            return true;
        }

        public static User create(string nickname, string group_id)
        {
            if(isValid(nickname, group_id)) {
                return new User(group_id, nickname);
            }
            return null;
        }

        public IMessage sendmessege(string body, string url)
        {
            IMessage msg = Communication.Instance.Send(url, this.Group_Id, this.NickName, body);

            //Message m = new Message(this, msg.Id, msg.Date, msg.MessageContent);
            return msg;
        }

        public void login()
        {

        }

        public void logout()
        {

        }


    }//test number 2
}

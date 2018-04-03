using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;
using milstone1.persistentLayer;

namespace milstone1.logic_Layer
{
    public class User
    {
        private string NickName;
        private string Group_Id;

        public User(string nickname, string group_id)
        {
            this.Group_Id = group_id;
            this.NickName = nickname;
        }

        public String GetNickname() {
            return this.NickName;
        }
        public String GetGroup_Id() {
            return this.Group_Id;
        }
        private static bool isValid(string nickname, string group_id)
        {
            return true;
        }

        public static User create(string nickname, string group_id)
        {
            if (isValid(nickname, group_id)) {
                return new User(group_id, nickname);
            }
            return null;
        }

        public IMessage sendmessege(string body, string url)
        {
            IMessage msg = Communication.Instance.Send(url, this.Group_Id, this.NickName, body);
            saveMessage(msg);
            

            //Message m = new Message(this, msg.Id, msg.Date, msg.MessageContent);
            return msg;
        }

        public void login()
        {

        }

        public void logout()
        {

        }
        public void saveMessage(IMessage msg)
        {
            IList<IMessage> msgToSave = new List <IMessage>( );
            msgToSave.Add(msg);
            FilesHandler.SaveMessages(msgToSave);
            
        }

        public bool IsEqual(User user)
        {
             { return (this.NickName == user.NickName) && (this.Group_Id == user.Group_Id); }
        
}

        public string ToString()
        {
            return this.GetNickname() +  " " + this.GetGroup_Id();
        }
    }
}

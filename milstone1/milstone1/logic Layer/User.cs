using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;
using milstone1.persistentLayer;

namespace milstone1.logic_Layer
{
    [Serializable]
    public class User
    {
        private string NickName;
        private string Group_Id;

        public User(string nickname, string group_id)
        {
            this.Group_Id = group_id;
            this.NickName = nickname;
        }

        public String GetNickname()
        {
            return this.NickName;
        }
        public String GetGroup_Id()
        {
            return this.Group_Id;
        }
        private static bool isValid(string nickname, string group_id)
        {
            return true;
        }

        public static User create(string nickname, string group_id)
        {
            if (isValid(nickname, group_id))
            {
                return new User(nickname, group_id);
            }
            return null;
        }

        public Message SendMessege(string body, string url)
        {

            if (body.Length > 150)
                throw new Exception("message canot be longer than 150 letters");
            else
            {
                IMessage msg = Communication.Instance.Send(url, this.Group_Id, this.NickName, body);
                Message mess = new Message(msg);
                saveMessage(mess);
                

                //Message m = new Message(this, msg.Id, msg.Date, msg.MessageContent);
                return mess;
            }
        }

        public void login()
        {

        }

        public void logout()
        {

        }
        public void saveMessage(Message msg)
        {
            IList<Message> msgToSave = new List<Message>();
            msgToSave.Add(msg);
            FilesHandler.SaveMessages(msgToSave);

        }

        public bool IsEqual(User user)
        {
            { return ((this.NickName == user.NickName) && (this.Group_Id == user.Group_Id)); }

        }

        public string ToString()
        {
            return this.GetNickname() + "," + this.GetGroup_Id();
        }
    }
}
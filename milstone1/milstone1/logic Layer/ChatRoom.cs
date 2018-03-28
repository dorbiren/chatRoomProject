using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;
using milstone1.presentaionLayer;

namespace milstone1.logic_Layer
{
    public class ChatRoom
    {
        private User loggedInUser;
        private List<User> userList;
        private List<IMessage> messagesList;
        private string url;
    

        public ChatRoom()
        { 
           
        }

       
        private bool userExists(User user)
        {
            if (/* check is user is not in the list */)
            {
                return true;
            }
            else
            {
                throw new Exception("user already exists");
            }
        }

        internal void sendMessage(string message)
        {
            IMessage msg = loggedInUser.sendmessege(message,url);
            messagesList.Add(msg);
        }

        public void registration(string nickName, string group_id) {
            User user = User.create(nickName, group_id);
            if (userExists(user))
            {
                userList.Add(user);
                return;
            }
        }

        public void login(String nickName, string group_id)
        {
            User user = null /*get from list*/;
            if (user == null)
            {
                throw new Exception("no such usser");
            } else
            {
                loggedInUser = user;
                user.login();
            }
        }

        public void retriveMessages (int number)
        {
            IList<IMessage> mesagges = Communication.Instance.GetTenMessages(this.url);
            messagesList.AddRange(messages);
        }

        public string displayMessages(int number)
        {
            
        }

        
}

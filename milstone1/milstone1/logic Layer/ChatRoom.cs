using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;
using milstone1.presentaionLayer;
using milstone1.persistentLayer;

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
            this.messagesList = FilesHandler.readMessagesFromFile();
            this.userList = FilesHandler.readUsersFromFile();
        }


        private bool userExists(User user)
        {
            foreach (User u in this.userList) {
                if (u.Equals(user))
                    return true;
            }
            throw new Exception("user already exists");
        }

        internal void sendMessage(string message)
        {
            IMessage msg = loggedInUser.sendmessege(message, url);
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
            foreach (User u in this.userList)
            {
                if (u.NickName.Equals(nickName) && u.Group_Id.Equals(group_id))
                {
                    loggedInUser = u;
                    u.login();
                    return;
                }
            }
            {
                throw new Exception("no such user");
            }
        }

            public void retriveMessages(int number)
            {
                IList<IMessage> messages = Communication.Instance.GetTenMessages(this.url);
                messagesList.AddRange(messages);
                FilesHandler.SaveMessages(messages);

            }

            public List<IMessage> displayMessages(int number)
            {
                List<IMessage> msg = new List<IMessage>();
                if (messagesList.Count >= number)
                {
                    for (int i = 0; i < number; i++)
                    {
                        msg.Insert(i, messagesList[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < messagesList.Count; i++)
                    {
                        msg.Insert(i, messagesList[i]);
                    }
                }
                return msg;
            }

            public void logOut()
            {

            }


        }
    }

    

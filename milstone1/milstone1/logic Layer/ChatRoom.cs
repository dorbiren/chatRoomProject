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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private User loggedInUser;
        private List<User> userList;
        private List<Message> messagesList;
        private string url;


        public ChatRoom()
        {
            this.messagesList = FilesHandler.ReadMessagesFromFile();
            this.userList = FilesHandler.ReadUsers();
            this.url = "http://ise172.ise.bgu.ac.il:80";
        }


        private bool userNotExists(User user)
        {
            foreach (User u in this.userList)
            {
                if (u.IsEqual(user))
                    throw new Exception("user already exists");
            }
            return true;
        }

        internal void sendMessage(string message)
        {
           
            Message msg = loggedInUser.SendMessege(message, url);
            messagesList.Add(msg);
            FilesHandler.SaveMessages(this.messagesList);
            return;

        }

        public void registration(string nickName, string group_id)
        {
            User user = User.create(nickName, group_id);

            if (userNotExists(user))
            {
                userList.Add(user);
                FilesHandler.SaveUsers(this.userList);
                return;
            }
        }

        public void login(String nickName, string group_id)
        {
            foreach (User u in this.userList)
            {
                if (u.GetNickname().Equals(nickName) && u.GetGroup_Id().Equals(group_id))
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
            try
            {
                IList<IMessage> messages = Communication.Instance.GetTenMessages(this.url);
                List<Message> Nmessages = new List<Message>();
                foreach (IMessage M in messages)
                {
                    Message M2 = new Message(M);
                    Nmessages.Add(M2);
                }
                foreach (Message mess in Nmessages.ToList())
                {
                    foreach (Message msg in this.messagesList.ToList())
                    {
                        if (mess.Id.Equals(msg.Id))
                            Nmessages.Remove(mess);
                    }
                }
                messagesList.AddRange(Nmessages);
                List<Message> SortedList = this.messagesList.OrderBy(o => o.Date).ToList();
                this.messagesList = SortedList;
                FilesHandler.SaveMessages(this.messagesList);
            }
            catch (Exception e)
            {

                log.Error("error for reterive messeage", e);
            }
            log.Info("reterive messeages succesfully");

        }

        public List<Message> displayMessages(int number)
        {
            List<Message> msg = new List<Message>();
            if (messagesList.Count >= number)
            {
                for (int i = 0; i < number; i++)
                {
                    msg.Insert(i, messagesList[messagesList.Count-1-i]);
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
            this.loggedInUser.logout();
            this.loggedInUser = null;

        }

        public void Exit()
        {
          
        }

        public  List<Message> displayAll(string NickName, string Group_Id)
        {
            List<Message> msg = new List<Message>();
                 foreach (Message M in this.messagesList)
            {
                if (M.GroupID.Equals(Group_Id) && M.UserName.Equals(NickName))
                    msg.Add(M);
            }
            List<Message> SortedList = msg.OrderBy(o => o.Date).ToList();
            return SortedList;
        }


    }
}
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
        private int state;
        //state =0 Manue, 
        //state =1 Register
        private Gui gui;

        public ChatRoom()
        { 
            gui = new Gui(this);
        }

        public void start()
        {
            //read from stroge
            state = 0;
            stateAnalyze();
        }

        /*private void stateAnalyze()
        {
            switch (state)
            {
                case 0: gui.Menu(); break;
                case 1: gui.Register(); break;
                case 2: gui.Login(); break;
                default: break;
            }

        }*/
        /*public void handler(String input)
        {
            switch (state)
            {
                case 0:
                    switch (input)
                    {
                        case "1": state = 1; stateAnalyze(); break;
                        case "2": state = 2; stateAnalyze(); break;
                        default: gui.Error("invalid input, insert again"); break;
                    }
                    break;
                case 1:
                    switch (input)
                    {
                        case "1": state = 0; stateAnalyze(); break;
                    }

                    break;
                case 2:
                    switch (input)
                    {
                        case "1": state = 0; stateAnalyze(); break;
                    }
                    break;
                default:

                    break;
            }
        }*/
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

        public string displayAll()
         {

         }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.logic_Layer;
using milstone1.CommunicationLayer;
using milstone1.persistentLayer;


namespace milstone1.presentaionLayer
{

    public class Gui
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ChatRoom chatroom;
        public Gui(ChatRoom chatroom)
        {
            this.chatroom = chatroom;
        }

        public void start()
        {

            this.MainMenu();
        }

        public void MainMenu()
        {

            Console.WriteLine("WELCOME TO CHATRoom");
            Console.WriteLine("1 register");
            Console.WriteLine("2 login");
            Console.WriteLine("3 exit");
            Console.WriteLine("insert a value");
            string answer = Console.ReadLine();
            try
            {
                int ans = int.Parse(answer);
                switch (ans)
                {
                    case 1:
                        DeletScreen();
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        Exit();
                        break;

                    default:
                        DeletScreen();
                        Console.WriteLine("PLEASE INSERT NUMBERS BETWEEN 1-3");
                        this.MainMenu();
                        break;
                }

            }
            catch (Exception e)
            {

                DeletScreen();
                Console.WriteLine(e.Message);
                log.Error("This is the error", e);
                MainMenu();
            }

        }

        public void Exit()
        {
           
            System.Environment.Exit(0);
        }
        public void Register()
        {

            Console.WriteLine("Register");
            Console.WriteLine("insert nick name");
            string nickName = Console.ReadLine();
            Console.WriteLine("insert group_id");
            string group_id = Console.ReadLine();
            try
            {
                chatroom.registration(nickName, group_id);
                this.Login();
            }
            catch (Exception e)
            {
                DeletScreen();
                Console.WriteLine(e.Message);
                this.MainMenu();

            }

        }
        public void Login()
        {
            DeletScreen();
            Console.WriteLine("LOGIN");
            Console.WriteLine("insert nick name");
            string nickName = Console.ReadLine();
            Console.WriteLine("insert group_id");
            string group_id = Console.ReadLine();
            try
            {
                this.chatroom.login(nickName, group_id);
                DeletScreen();
                chat();
            }
            catch (Exception e)
            {
                DeletScreen();
                Console.WriteLine(e.Message);
                this.MainMenu();

            }
        }

        private void sendMessage()
        {
            DeletScreen();
            Console.WriteLine("Write new message");
            string message = Console.ReadLine();
            try
            {
                chatroom.sendMessage(message);
                DeletScreen();
                Console.WriteLine("message send succefuly");
                chat();
            }
            catch  (Exception e)
            {
                DeletScreen();
                Console.WriteLine(e.Message);
                chat();
            }
        }

        public void chat()
        {

            Console.WriteLine("Welcome back!");
            Console.WriteLine("1 send message");
            Console.WriteLine("2 retrieve 10 messages");
            Console.WriteLine("3 display 20 messages");
            Console.WriteLine("4 display all messages of a user");
            Console.WriteLine("5 log out");

            string answer = Console.ReadLine();
            try
            {
                int ans = int.Parse(answer);
                switch (ans)
                {
                    case 1:
                        sendMessage();
                        break;
                    case 2:
                        RetrieveMessage();
                        break;
                    case 3:
                        DisplayMessage();
                        break;
                    case 4:
                        DeletScreen();
                        this.displayAllbyuser();
                        break;
                    case 5:
                        this.chatroom.logOut();
                        DeletScreen();
                        MainMenu();
                        break;
                    default:
                        DeletScreen();
                        Console.WriteLine("PLEASE INSERT NUMBERS BETWEEN 1-5");
                        this.chat();
                        break;
                }
            }
            catch (Exception e)
            {
                DeletScreen();
                Console.WriteLine(e.Message);
                chat();
            }
        }
        public void RetrieveMessage()
        {
            this.chatroom.retriveMessages(10);
            DeletScreen();
            Console.WriteLine("messages retrieved succecfuly");
            chat();
        }

        public void DisplayMessage()
        {
            DeletScreen();
            List<Message> meseeglist = this.chatroom.displayMessages(20);

            foreach (Message mess in meseeglist)
            {
                Console.WriteLine(mess.ToString());
            }

            chat();
        }

        public void Error(String error)
        {
            delettnumberlastlines(2);
            Console.WriteLine(error);
            string a = Console.ReadLine();
        }
        private void DeletScreen()
        {
            Console.Clear();
        }
        private void delettnumberlastlines(int a)
        {
            for (int i = 0; i < a; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new String(' ', 100));
            }
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        private void displayAllbyuser()
        {
            Console.WriteLine("insert nickname");
            string nick=Console.ReadLine();
            Console.WriteLine("insert groupid");
            string groupid=Console.ReadLine();
            DeletScreen();
            List<Message> msg = this.chatroom.displayAll(nick, groupid);
            if (msg.Count == 0)
            {
                Console.WriteLine("there are no such messages");
                this.chat();
            }
            foreach (Message mess in msg)
            {
                Console.WriteLine(mess.ToString());
            }
            this.chat();



        }

    }
}
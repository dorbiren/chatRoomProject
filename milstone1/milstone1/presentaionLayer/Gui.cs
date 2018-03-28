using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.logic_Layer;

namespace milstone1.presentaionLayer
{
    public class Gui
    {
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
           DeletScreen(); 
           Console.WriteLine("WELCOME TO CHATRoom");
           Console.WriteLine("1 register");
           Console.WriteLine("2 login");
           Console.WriteLine("3 exit");
           Console.WriteLine("insert a value");
           string answer = Console.ReadLine();
            int ans = int.Parse(answer);
            switch (ans)
            {
                case 1:
                    Register();
                    break;
                case 2:
                    Login();
                    break;
                case 3:
                    Exit();
                    break;
            }
         }
        public void Register()
        {
            DeletScreen();
            Console.WriteLine("Register");
            Console.WriteLine("insert nick name");
            string nickName = Console.ReadLine();
            Console.WriteLine("insert group_id");
            string group_id = Console.ReadLine();
            try
            {
                chatroom.registration(nickName, group_id);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.WriteLine("1 back to manue");
            //Console.WriteLine("2 exit");
            chatroom.registration(nickName, g_id);
        }
        public void Login()
        {
            DeletScreen();
            Console.WriteLine("Login");
            Console.WriteLine("1 back to manue");
            Console.WriteLine("2 send message");
            chatroom.handler(Console.ReadLine());
        }

        private void sendMessage()
        {
            DeletScreen();
            Console.WriteLine("Write new message");
            string message = Console.ReadLine();
            chatroom.sendMessage(message);
        }

        public void chat()
        {
            DeletScreen();
            Console.WriteLine("Welcome back!");
            Console.WriteLine("1 send message");
            Console.WriteLine("2 retrieve 10 messages");
            Console.WriteLine("3 display 20 messages");
            Console.WriteLine("4 back to main menu");

            string answer = Console.ReadLine();
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
                    MainMenu();
                    break;
            }
        }

        public void Error(String error)
        {
            delettnumberlastlines(2);
            Console.WriteLine(error);
            chatroom.handler(Console.ReadLine());
        }
        private void DeletScreen()
        {
            Console.Clear();
        }
        private void delettnumberlastlines(int a)
        {
            for(int i=0;i<a;i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new String(' ', 100));
            }
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}

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
        public void Menu()
        {
           DeletScreen(); 
           Console.WriteLine("WELCOME TO CHATRoom");
           Console.WriteLine("1 register");
           Console.WriteLine("2 login");
           Console.WriteLine("3 exit");
            Console.WriteLine("insert a value");
            chatroom.handler(Console.ReadLine());
         }
        public void Register()
        {
            DeletScreen();
            Console.WriteLine("Register");
            Console.WriteLine("insert nick name");
            String nickName = Console.ReadLine();
            Console.WriteLine("insert group_id");
            String group_id = Console.ReadLine();
            chatroom.registration(nickName, group_id);
            Console.WriteLine("1 back to manue");
            Console.WriteLine("2 exit");
            chatroom.handler(Console.ReadLine());
        }
        public void Login()
        {
            DeletScreen();
            Console.WriteLine("Login");
            Console.WriteLine("1 back to manue");
            Console.WriteLine("2 exit");
            chatroom.handler(Console.ReadLine());
        }
        public void chat()
        {

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

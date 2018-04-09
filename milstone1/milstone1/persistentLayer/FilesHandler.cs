using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;
using milstone1.logic_Layer;

namespace milstone1.persistentLayer
{
    public class FilesHandler
    {

        public static void SaveMessages(IList<IMessage> messages)
        {

            using (StreamWriter sw = new StreamWriter(@"C:\Users\dorbi\OneDrive\Desktop\study\coms\repos\chatRoomProject\milstone1\milstone1\persistentLayer\messages.csv"))
            {

                foreach (IMessage msg in messages)
                {
                    sw.WriteLine(msg.ToString());
                }
            }


        }
        public static void SaveUsers(IList<User> users)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\dorbi\OneDrive\Desktop\study\coms\repos\chatRoomProject\milstone1\milstone1\persistentLayer\users.csv"))
            {

                foreach (User U in users)
                {
                    sw.WriteLine(U.ToString());
                }
            }
        }
        public static void SaveUser(User user)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\dorbi\OneDrive\Desktop\study\coms\repos\chatRoomProject\milstone1\milstone1\persistentLayer\users.csv"))
                sw.WriteLine(user.ToString());
        }
        public static List<User> ReadUsers()
        {
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            using (var rd = new StreamReader(@"C:\Users\dorbi\OneDrive\Desktop\study\coms\repos\chatRoomProject\milstone1\milstone1\persistentLayer\users.csv"))
            {
                while (!rd.EndOfStream)
                {   //saving user data into 2 lists (1 for username ,1 for groupid)
                    var splits = rd.ReadLine().Split(',');
                    column1.Add(splits[0]);
                    column2.Add(splits[1]);
                }

            }

            List<User> user = column1.Zip(column2, (name, age) => new User(name, age))
    .ToList();

            return user;
        }
        /*public static List<Message> ReadMessages()
        {
            List<string> column1 = new List<string>();
            List<string> column2 = new List<string>();
            List<string> column3 = new List<string>();
            List<string> column4 = new List<string>();
            List<string> column5 = new List<string>();
            List<string> column6 = new List<string>();
            using (var rd = new StreamReader(@"C:\Users\dorbi\OneDrive\Desktop\study\coms\repos\chatRoomProject\milstone1\milstone1\persistentLayer\messages.csv"))
                while (!rd.EndOfStream)
            {   //saving user data into 2 lists (1 for username ,1 for groupid)
                var splits = rd.ReadLine().Split(',');
                column1.Add(splits[0]);
                column2.Add(splits[1]);
                column3.Add(splits[2]);
                column4.Add(splits[3]);
                column5.Add(splits[4]);
                column6.Add(splits[5]);


                }
        }*/

    }
}
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
            using (StreamWriter sw = new StreamWriter(@"C:\Users\dorbi\OneDrive\Desktop\study\coms\repos\chatRoomProject\milstone1\milstone1\persistentLayer\messages.csv"))
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
        
    }

        
    }


using System;
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
        
        public static void SaveMessages(List<IMessage> messages)
        {

        }

        public static void SaveUsers(List<User> users)
        {

        }

        public static List<IMessage> readMessagesFromFile()
        {
            throw new NotImplementedException();
        }

        public static List<User> readUsersFromFile()
        {
            throw new NotImplementedException();
        }

        internal static void SaveMessages(IList<IMessage> messages)
        {
            throw new NotImplementedException();
        }
    }
}

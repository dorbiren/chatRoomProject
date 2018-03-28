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
        
        public void SaveMessages(IList<IMessage> messages)
        {

        }

        public void SaveUsers(IList<User> users)
        {

        }

        public IList<IMessage> readMessagesFromFile()
        {
            throw new NotImplementedException();
        }

        public IList<User> readUsersFromFile()
        {
            throw new NotImplementedException();
        }
    }
}

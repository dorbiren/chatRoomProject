using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;
using milstone1.logic_Layer;
using System.Runtime.Serialization.Formatters.Binary;
namespace milstone1.persistentLayer
{
    public class FilesHandler
    {

        public static void SaveMessages(IList<Message> messages)
        {

            Stream myFileStream = File.Create("messagesdata.bin");
            BinaryFormatter serializes = new BinaryFormatter();
            serializes.Serialize(myFileStream, messages);
            myFileStream.Close();
        }
        public static void SaveUsers(IList<User> users)
        {
            Stream myFileStream = File.Create("usersdata.bin");
            BinaryFormatter serializes = new BinaryFormatter();
            serializes.Serialize(myFileStream, users);
            myFileStream.Close();
        }
        public static List<User> ReadUsers()
        {
            List<User> usersList = new List<User>();
            if (File.Exists("usersdata.bin"))
            {
                Stream myOtherFileStream = File.OpenRead("usersdata.bin");
                BinaryFormatter deserializer = new BinaryFormatter();
                usersList = (List<User>)deserializer.Deserialize(myOtherFileStream);
                myOtherFileStream.Close();

            }
            return usersList;
        }
        public static List<Message> ReadMessagesFromFile()
        {
            List<Message> MsgList = new List<Message>();
            if (File.Exists("messagesdata.bin"))
            {
                Stream myOtherFileStream = File.OpenRead("messagesdata.bin");
                BinaryFormatter deserializer = new BinaryFormatter();
                MsgList = (List<Message>)deserializer.Deserialize(myOtherFileStream);
                myOtherFileStream.Close();

            }
            return MsgList;
        }
    }
}

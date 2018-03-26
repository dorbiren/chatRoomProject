using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.CommunicationLayer;

namespace milstone1.logic_Layer
{
    class User
    {
        private String nickName;
        private int group_id;
        
        public void sendmessege (string body)
        {
           IMessage msg =  Communication.Instance.Send(url, this.group_id, this.nickName, body);
        }


    }
}

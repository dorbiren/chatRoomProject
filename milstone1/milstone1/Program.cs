using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.presentaionLayer;
using milstone1.logic_Layer;

namespace milstone1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChatRoom c = new ChatRoom();
            Gui a = new Gui(c);
            a.start();
        }
    }
}

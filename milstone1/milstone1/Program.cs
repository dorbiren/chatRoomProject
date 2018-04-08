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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            try
            {
                log.Info("start my log");
                ChatRoom c = new ChatRoom();
                Gui a = new Gui(c);
                a.start();
            }
            catch(Exception e)
            {
                log.Error("this is error", e);

            }
            log.Info("exit chat room");
        }
    }
}

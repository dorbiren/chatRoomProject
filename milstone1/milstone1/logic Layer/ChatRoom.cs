using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using milstone1.presentaionLayer;

namespace milstone1.logic_Layer
{
    public class ChatRoom
    {
        private User loggedInUser;
        private string url;
        private int state;
        //state =0 Manue, 
        //state =1 Register
        private Gui gui;
        public ChatRoom()
        {
            gui = new Gui(this);
        }
        public void start()
        {
            //read from stroge
            state = 0;
            stateAnalyze();
        }
        private void stateAnalyze()
        {
            switch(state)
            {
                case 0: gui.Manue(); break;
                case 1: gui.Register(); break;
                case 2: gui.Login(); break;
                default: break;
            }
            
        }
        public void handler(String input)
        {
            switch (state)
            {
                case 0:
                    switch(input)
                    {
                        case "1": state = 1; stateAnalyze(); break;
                        case "2": state = 2; stateAnalyze(); break;
                        default: gui.Error("invalid input, insert again"); break;
                    }
                    break;
                case 1:
                    switch (input)
                    {
                        case "1": state = 0; stateAnalyze(); break;
                    }

                    break;
                case 2:
                    switch (input)
                    {
                        case "1": state = 0; stateAnalyze(); break;
                    }
                    break;
                default:

                    break;
            }
        }
        public void registration(string nickName, int group_id, int password, string countery);

    }
}

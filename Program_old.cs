using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using MAIN_GUI_Mangaer_window.ma_controller;
using main.srv2;
using System.Threading;
namespace main.srv
{
    public static class MainClass
    {

        public static Thread SocketThread = new Thread(ServerListen.Server);


        public static void pMain()
        {
             SocketThread.Start();
        }

       
    }

}

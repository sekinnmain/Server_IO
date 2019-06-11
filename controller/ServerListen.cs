using MAIN_GUI_Mangaer_window.ma_controller;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml;

namespace main.srv2
{

    public static class ServerListen

    {
        

        public static void Server()

        {

            while(true)
            {

                Int32 port = 9999;

                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                TcpListener OneTcpListener = new TcpListener(localAddr, port);
                Console.WriteLine("Waiting for a client...");

                OneTcpListener.Start();

                Socket ClientSocket = OneTcpListener.AcceptSocket();

                if (ClientSocket.Connected)

                {
                    //socket.Bind(ip);
                    //socket.Listen(10);
                    //Console.WriteLine("Waiting for a client...");
                    //Socket client = socket.Accept();
                    //IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
                    //Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);
                    XmlDocument myDoc = new XmlDocument();
                    myDoc.Load(XmlParser.xmlOrders);
                    string welcome = $"{GetXMLAsString(myDoc)}";
                    byte[] data = new byte[1024];
                    data = Encoding.ASCII.GetBytes(welcome);
                    ClientSocket.Send(data, data.Length, SocketFlags.None);

                }
                ClientSocket.Close();
            }
            
        }
        public static string GetXMLAsString(XmlDocument myxml)
        {

            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            myxml.WriteTo(tx);

            string str = sw.ToString();// 
            return str;
        }


    }


}

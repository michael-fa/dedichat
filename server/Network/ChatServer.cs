using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Lidgren.Network;



namespace server.Network
{
    public class ChatServer : ServerCore
    {
        public NetConnectionStatus m_Status;


        private NetServer m_NetServer;
        private NetPeerConfiguration m_Config;

        public ChatServer(int port, string host = "127.0.0.1")
        {
            m_Config = new NetPeerConfiguration("dedichat")
            { Port = port };
            m_NetServer = new NetServer(m_Config); //test
            try
            {
                m_NetServer.Start();
                
            }
            catch(Exception ex)
            {
                //...
            }

            Thread newThread = new Thread(new ThreadStart(Listen));
            newThread.Start();
        }



        public void Listen()
        {
            while (true)
            {
                NetIncomingMessage message;
                while ((message = m_NetServer.ReadMessage()) != null)
                {
                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            // handle custom messages
                            Console.WriteLine("MSG: " + message.ReadString());
                            break;

                        case NetIncomingMessageType.StatusChanged:
                            // handle connection status messages
                            Console.WriteLine("<INFO>" + message.SenderEndPoint.ToString() + " status changed to " + message.SenderConnection.Status.ToString());
                            switch (message.SenderConnection.Status)
                            {
                                /* .. */

                            }
                            break;

                        case NetIncomingMessageType.DebugMessage:
                            // handle debug messages
                            // (only received when compiled in DEBUG mode)
                            Console.WriteLine(message.ReadString());
                            break;

                        /* .. */
                        default:
                            Console.WriteLine("unhandled message with type: "
                                + message.MessageType);
                            break;
                    }
                }
            }
        }
    }
}

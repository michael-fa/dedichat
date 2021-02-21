
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using server.Network;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.WriteLine("Dedicated Chat Server v" + common.g_Version + " by Michael Fanter", System.Drawing.Color.Yellow);

            ChatServer chServer = new ChatServer(7777);


            read:
            string inp = Console.ReadLine();
            goto read;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Logic: Once we start the app, the fist Form will be the main-connector form.  
            //This program sends all data that we work with to the server, and if the server accepts the client we will open another form, whích is fully for the server.


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ConnectionForm());
            Application.Run(new Chat());
        }
    }
}

using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Chat : Form
    {

        public NetClient Client;
        public NetConnection gConn;
        public Chat()
        {
            InitializeComponent();

            
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rtb_ClientCmd.Text.Length > 0) rtb_ClientCmd.Text = rtb_ClientCmd.Text + "\n" + tb_ClientCmd.Text;
                else rtb_ClientCmd.Text = tb_ClientCmd.Text;
                tb_ClientCmd.Text = "";

               

            }
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
  
        }

        private void tb_Chat_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (rtb_Chat.Text.Length > 0) rtb_Chat.Text = rtb_Chat.Text + "\n" + tb_Chat.Text;
                else rtb_Chat.Text = tb_Chat.Text;

                var message = Client.CreateMessage();
                message.Write(tb_Chat.Text);

                Client.SendMessage(message, recipient: gConn,
                NetDeliveryMethod.ReliableOrdered);

                tb_Chat.Text = "";
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            var config = new NetPeerConfiguration("dedichat");
            Client = new NetClient(config);
            Client.Start();
            try
            {
                gConn = Client.Connect(host: "127.0.0.1", port: 7777);
            }
            catch (Exception ex)
            {
                rtb_ClientCmd.Text = rtb_ClientCmd.Text + "\n" + ex.Message + "\n----\n" + ex.Source;
            }
        }

        private void Chat_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            gConn.Disconnect("Form closing");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SimpleTcp;

namespace PROJECT_HBS
{
    public partial class MainGUI : Form
    {
        
        string Username;

        public MainGUI(string text)
        {
            InitializeComponent();
            Username = text;
            UsernameBox.Text = Username;
            StartConnect();
            UpdateButton.Enabled = false;
        }

    

        //-------------------------------------------------------------LẬP TRÌNH KẾT NỐI SERVER--------------------------------------------------------------------
        SimpleTcpClient Client;
        int COMMUNICATE_PORT = 9999;
        string IP_CLIENT = "127.0.0.1";

        void StartConnect()
        {
            Client = new SimpleTcpClient(IP_CLIENT + ":" + COMMUNICATE_PORT);
            try
            {
                Client.Connect();
      
            }
            catch
            {
                DialogResult tb = MessageBox.Show("Không Kết Nối Được Đến Server", "Lỗi Kết Nối", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (tb == DialogResult.Retry)
                {
                    StartConnect();
                }
            }

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------

        void GetInforUser()
        {
            string Request = "5SELECT * FROM Account WHERE Username='" + Username + "'";
            Send(Request);
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            Client.Events.Connected += Events_Connected;
            Client.Events.DataReceived += Events_DataReceived;
            Client.Events.Disconnected += Events_Disconnected1;
        }

        private void Events_Disconnected1(object sender, ClientDisconnectedEventArgs e)
        {
            MessageBox.Show("Đã Ngắt Kết Nối Đến Server");
        }
        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string Answer = Encoding.UTF8.GetString(e.Data);
            if (Answer == "Success")
            {
                MessageBox.Show("Thao Tác Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else CheckAnswer(Answer);
        }

        void CheckAnswer(string Answer)
        {
            if (Answer[0] == '5') GetDataUser(Answer);
        }

        void GetDataUser(string Answer)
        {
            Answer = Answer.Remove(0, 1);
            string[] ArrayString = Answer.Split(" ");
            this.Invoke((MethodInvoker)delegate
            {
                NameInfo.Text = ArrayString[2].Replace('+',' ');
                PhoneInfor.Text = ArrayString[3];
                EmailInfor.Text = ArrayString[4];
            });
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void Send(string Request)
        {
            if (Client.IsConnected)
            {
                Client.Send(Request);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc chắn muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(tb==DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }    
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string NameTemp = NameInfo.Text.Trim();
                NameTemp = NameTemp.Replace(" ", "+");
                string Request = "6UPDATE Account SET Email='" + EmailInfor.Text.Trim() + "'" + ",Phone='" + PhoneInfor.Text.Trim() + "'" + ",GuestName=" + "'" + NameTemp + "'" + "WHERE Username='" + UsernameBox.Text.Trim() + "'";
                Send(Request);
            }
            catch
            {
               DialogResult tb = MessageBox.Show("Mất Kết Nối Server","Thông báo",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
               if(tb==DialogResult.Retry)
                {
                    StartConnect();
                }    
            }
        }

        private void ShowUserInfor_Click(object sender, EventArgs e)
        {
            GetInforUser();
            this.Invoke((MethodInvoker)delegate
           {
               UpdateButton.Enabled = true;
           });
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            WellcomeGUI obj = new WellcomeGUI();
            obj.Show();
            this.Hide();
        }
    }
}

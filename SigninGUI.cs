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
using System.Runtime.InteropServices;

namespace PROJECT_HBS
{
    public partial class SigninGUI : Form
    {
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
        public SigninGUI()
        {
            InitializeComponent();
            StartConnect();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            WellcomeGUI obj = new WellcomeGUI();
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(tb==DialogResult.OK)
            {
                Application.Exit();
            }    
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsernameBox.Clear();
            PassBox.Clear();
            PassConfirmBox.Clear();
            EmailBox.Clear();
            PhoneBox.Clear();
        }

     

        //--------------------------------------------------------------------------------SIGN IN BUTTON-------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Tên Đăng Nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (EmailBox.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Tên Email", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PhoneBox.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Tên Đăng Nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PassBox.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Tên Mật Khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PassConfirmBox.Text == "")
            {
                MessageBox.Show("Vui Lòng Xác Nhận Mật Khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PassConfirmBox.Text != PassBox.Text)
            {
                MessageBox.Show("Vui Lòng Mật Khẩu Xác Nhận Không Khớp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!Client.IsConnected)
                {
                    StartConnect();
                }
                string Request = "1SELECT * FROM Account WHERE Username = " + "'" + UsernameBox.Text.Trim() + "'";
                Send(Request);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void SigninGUI_Load(object sender, EventArgs e)
        {

                Client.Events.Connected += Events_Connected;
                Client.Events.Disconnected += Events_Disconnected;
                Client.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string Answer = Encoding.UTF8.GetString(e.Data);
            //MessageBox.Show(Answer);
            if(Answer!=" ")
            {
                MessageBox.Show("Tên Đăng Nhập Đã Được Sử Dụng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Request = "2INSERT INTO Account(Username,Password,Phone,Email) VALUES('" + UsernameBox.Text.Trim() + "','" + PassBox.Text.Trim() + "','" + PhoneBox.Text.Trim() + "','" + EmailBox.Text.Trim() + "')";
                Send(Request);
                MessageBox.Show("Đăng Ký Tài Khoản Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainGUI obj = new MainGUI(UsernameBox.Text);
                this.Invoke((MethodInvoker)delegate
                {
                    obj.Show();
                    this.Hide();
                });
            }
        }

        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            DialogResult tb = MessageBox.Show("Server ngắt kết nối", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            if(tb==DialogResult.Retry)
            {
                StartConnect();
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            MessageBox.Show("Đã kết nối đến Server ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void Send(string Request)
        {
            if(Client.IsConnected)
            {
                Client.Send(Request);
            }    
        }
        //---------------------------------------------------------------Create Moving-------------------------------------------
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
        }
        //-----------------------------------------------------------------------------------------------------------------------
    }
}

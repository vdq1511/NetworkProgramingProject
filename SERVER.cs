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
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SimpleTcp;
using System.Runtime.InteropServices;

namespace SERVER_HBS
{
    public partial class SERVER : Form
    {

        string Database_Link = (@"Data Source=DESKTOP-24A5G24\SQLEXPRESS;Initial Catalog=HOTELBOOKING;Integrated Security=True;MultipleActiveResultSets=true");
        SqlConnection sqlCon;


        ASCIIEncoding encoding = new ASCIIEncoding();
        int COMMUNICATE_PORT = 9999;
        string IP_SERVER = "127.0.0.1";

        List<Socket> Client_List = new List<Socket>();
        DateTime dateTime;

        SimpleTcpServer Server;

        //---------------------------------------------------------------------------------------------------------------------------------

        

        void StartConnect()
        {
            Server.Start();
            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += $"Bắt đầu Server.....{Environment.NewLine}";
            });
        }
        void CloseConnect()
        {
            Server.Stop();
            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += $"Tắt Server....{Environment.NewLine}";
            });

            
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------


        public SERVER()
        {
            InitializeComponent();
            sqlCon = new SqlConnection(Database_Link);
            sqlCon.Open();
            StopServerButton.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            StartConnect();
            StartServerButton.Invoke((MethodInvoker)delegate ()
           {
               StartServerButton.Enabled = false;
           });

            StopServerButton.Invoke((MethodInvoker)delegate ()
            {
                StopServerButton.Enabled = true;
            });
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            CloseConnect();

            StartServerButton.Invoke((MethodInvoker)delegate ()
            {
                StartServerButton.Enabled = true;
            });

            StopServerButton.Invoke((MethodInvoker)delegate ()
            {
                StopServerButton.Enabled = false;
            });
        }

        private void SERVER_Load(object sender, EventArgs e)
        {
            Server = new SimpleTcpServer(IP_SERVER + ":" + COMMUNICATE_PORT);
            Server.Events.ClientConnected += Events_ClientConnected;
            Server.Events.ClientDisconnected += Events_ClientDisconnected;
            Server.Events.DataReceived += Events_DataReceived;
        }


        //---------------------------------------------------------------------------XU LY EVENT---------------------------------------------------
        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
               ServerStatus.Text +=$"{ e.IpPort}:{ Encoding.UTF8.GetString(e.Data)}{Environment.NewLine }";
            });

            string Request = $"{ Encoding.UTF8.GetString(e.Data)}";
            SolveRequest(Request, e.IpPort);
        }

        private void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                 ServerStatus.Text +=$"{ e.IpPort} disconected.{Environment.NewLine }";
                 ClientList.Items.Remove(e.IpPort);
            });

           
        }

        private void Events_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
           {
               ServerStatus.Text += $"{ e.IpPort} connected.{Environment.NewLine }";
               ClientList.Items.Add(e.IpPort);
           });
           
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------




        void Send(string Answer,string adressclient)
        {
            if(Server.IsListening)
                if(ClientList.Items.Contains(adressclient))
                {
                    Server.Send(adressclient, Answer);
                    this.Invoke((MethodInvoker)delegate
                    {
                        ServerStatus.Text += "Đã phản hồi Client" + $"{adressclient}{Environment.NewLine}";
                    });
                }
        }


        void SolveRequest(string Request, string addresss)
        {
            if (Request[0] == '1') RequestSignIn_1(Request, addresss);
            else if (Request[0] == '2') RequestSignIn_2(Request, addresss);
            else if (Request[0] == '3') RequestLogin(Request, addresss);
            else if (Request[0] == '4') RequestGetUser_Exsist(Request, addresss);
            else if (Request[0] == '5') RequestGetUserInfor(Request, addresss);
            else if (Request[0] == '6') RequestUpdateUserInfor(Request, addresss);
        }

        //---------------------------------------------------------------------SIGN IN-------------------------------------------------------
        void RequestSignIn_1(string Request, string addresss)
        {
            Request = Request.Remove(0, 1);
            SqlDataAdapter sda = new SqlDataAdapter(Request, sqlCon);

            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += Request + $"{ Environment.NewLine}";
            });

            DataTable DTBL = new DataTable();
            sda.Fill(DTBL);
            string Result = "";
            if (DTBL.Rows.Count > 0)
                for (int i = 0; i < DTBL.Columns.Count; i++)
                {
                    if (DTBL.Rows[0][i] != null)
                        Result += DTBL.Rows[0][i].ToString() + " ";
                    else Result += "NULL ";
                }

            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += "This is result:" + $"{ Result} {Environment.NewLine }";
            });
            Result += " ";
            Send(Result, addresss);
        }

        void RequestSignIn_2(string Request,string address)
        {
            Request = Request.Remove(0, 1);
            SqlCommand command = new SqlCommand(Request, sqlCon);
            SqlDataReader sqlReader;
            sqlReader = command.ExecuteReader();
            Send("Success", address);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------


        //----------------------------------------------------LOGIN------------------------------------------------------------------------------
        void RequestLogin(string Request, string addresss)
        {
            Request = Request.Remove(0, 1);
            SqlDataAdapter sda = new SqlDataAdapter(Request, sqlCon);

            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += Request + $"{ Environment.NewLine}";
            });

            DataTable DTBL = new DataTable();
            sda.Fill(DTBL);
            string Result = "";
            if (DTBL.Rows.Count > 0)
                for (int i = 0; i < DTBL.Columns.Count; i++)
                {
                    if (DTBL.Rows[0][i] != null)
                        Result += DTBL.Rows[0][i].ToString() + " ";
                    else Result += "NULL ";
                }

            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += "This is result:" + $"{ Result} {Environment.NewLine }";
            });
            Result += " ";
            Send(Result, addresss);

        }
        //-------------------------------------------------------------------------------------------------------------------------------------


        //----------------------------------------------------------MAIN GUI--------------------------------------------------------------------
        void RequestGetUser_Exsist(string Request, string addresss)
        {
            Request = Request.Remove(0, 1);
            SqlDataAdapter sda = new SqlDataAdapter(Request, sqlCon);

            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += Request + $"{ Environment.NewLine}";
            });

            DataTable DTBL = new DataTable();
            sda.Fill(DTBL);
            string Result = "";
            if (DTBL.Rows.Count > 0)
                for (int i = 0; i < DTBL.Columns.Count; i++)
                {
                    if (DTBL.Rows[0][i] != null)
                        Result += DTBL.Rows[0][i].ToString() + " ";
                    else Result += "NULL ";
                }

            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += "This is result:" + $"{ Result} {Environment.NewLine }";
            });
            Result += " ";
            Send(Result, addresss);
        }

        void RequestGetUserInfor(string Request, string addresss)
        {
            Request = Request.Remove(0, 1);
            SqlDataAdapter sda = new SqlDataAdapter(Request, sqlCon);

            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += Request + $"{ Environment.NewLine}";
            });

            DataTable DTBL = new DataTable();
            sda.Fill(DTBL);
            string Result = "";
            if (DTBL.Rows.Count > 0)
                for (int i = 0; i < DTBL.Columns.Count; i++)
                {
                    if (DTBL.Rows[0][i] != null)
                        Result += DTBL.Rows[0][i].ToString() + " ";
                    else Result += "NULL ";
                }

            this.Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text += "This is result:" + $"{ Result} {Environment.NewLine }";
            });
            Result += " ";
            Send('5'+Result, addresss);
        }

        void RequestUpdateUserInfor(string Request, string addresss)
        {
            Request = Request.Remove(0, 1);
            SqlCommand command = new SqlCommand(Request, sqlCon);
            SqlDataReader sqlReader;
            sqlReader = command.ExecuteReader();
            Send("Success", addresss);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        private void ShowAllAccount_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Account", sqlCon);
            DataTable DTBL = new DataTable();
            sda.Fill(DTBL);

            AccountShow.DataSource = DTBL;
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            string Command = "DELETE FROM Account WHERE Username= '" + UserDelete.Text.Trim() + "'";
            SqlCommand command = new SqlCommand(Command, sqlCon);
            SqlDataReader reader;
            reader = command.ExecuteReader();
            AccountShow.Invoke((MethodInvoker)delegate
           {
               SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Account", sqlCon);
               DataTable DTBL = new DataTable();
               sda.Fill(DTBL);

               AccountShow.DataSource = DTBL;
           }
            );
            UserDelete.Clear();
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult tb= MessageBox.Show("Bạn Chắc Chắn Muốn Xóa Toàn Bộ Tài Khoản", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(tb==DialogResult.Yes)
            {
                string Command = "DELETE FROM Account";
                SqlCommand command = new SqlCommand(Command, sqlCon);
                SqlDataReader reader;
                reader = command.ExecuteReader();

                AccountShow.Invoke((MethodInvoker)delegate
                {
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Account", sqlCon);
                    DataTable DTBL = new DataTable();
                    sda.Fill(DTBL);

                    AccountShow.DataSource = DTBL;
                }
                );
            }    
        }

        //--------------------------------------------------------------------Create Moving----------------------------------
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ServerStatus.Clear();
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
}

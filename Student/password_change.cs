using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using System.Data.OleDb;

namespace Student
{
    public partial class password_change : Form
    {
        public password_change()
        {
            InitializeComponent();

            MessageBox.Show("비밀번호를 변경해주세요.");
            textBox1.Text = main.number;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String pw1 = textBox2.Text;
            String pw2 = textBox3.Text;

            if (pw1 == pw2)
            {
                if (pw1.Length >= 5)
                {
                    SHA256 hash = new SHA256Managed();
                    byte[] bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(pw1));

                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        sb.AppendFormat("{0:x2}", b);
                    }

                    String newpw = sb.ToString();

                    if(main.vals == "학생")
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        String query = $"UPDATE 학생 SET 비밀번호 = '{newpw}' WHERE 학번='{main.number}'";
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                        OleDbConnection conn = new OleDbConnection(ConnectString);
                        conn.Open();
                        cmd.Connection = conn;

                        OleDbDataReader read = cmd.ExecuteReader();

                        MessageBox.Show("비밀번호가 변경되었습니다.");
                        this.Close();
                    }
                    else if(main.vals == "교수")
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        String query = $"UPDATE 교수 SET 비밀번호 = '{newpw}' WHERE 교수번호='{main.number}'";
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.Text;
                        String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                        OleDbConnection conn = new OleDbConnection(ConnectString);
                        conn.Open();
                        cmd.Connection = conn;

                        OleDbDataReader read = cmd.ExecuteReader();

                        MessageBox.Show("비밀번호가 변경되었습니다.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("비밀번호가 너무 짧습니다.");
                }
            }
            else
            {
                MessageBox.Show("비밀번호가 다릅니다.");
            }
        }
    }
}

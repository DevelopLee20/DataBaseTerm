﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace Student
{
    public partial class main : Form
    {
        String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
        OleDbConnection conn;
        static public String number;

        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OleDbConnection(ConnectString);
            conn.Open();

            try
            {
                String val = comboBox1.Text;
                String id = textBox1.Text;
                String passwd = textBox2.Text;
                String query;

                if(val == "관리자" && id == "admin" && passwd == "123123")
                {
                    MessageBox.Show("어드민 페이지로 접속합니다.");
                    admin_page page = new admin_page();
                    page.Show();
                }
                else
                {
                    if (passwd != "0000")
                    {
                        SHA256 hash = new SHA256Managed();
                        byte[] bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(passwd));

                        StringBuilder sb = new StringBuilder();
                        foreach (byte b in bytes)
                        {
                            sb.AppendFormat("{0:x2}", b);
                        }

                        passwd = sb.ToString();
                    }

                    OleDbCommand cmd = new OleDbCommand();
                    query = $"SELECT * FROM {val} WHERE 학번='{id}' AND 비밀번호='{passwd}'";
                    cmd.CommandText = query;
                    Console.WriteLine($"SELECT * FROM {val} WHERE 학번={id} AND 비밀번호={passwd};");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    OleDbDataReader read = cmd.ExecuteReader();

                    if (!read.Read())
                    {
                        MessageBox.Show("없는 계정입니다.");
                    }
                    else
                    {
                        number = id;

                        if (passwd == "0000")
                        {
                            password_change page = new password_change();
                            page.Show();
                        }
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }
    }
}

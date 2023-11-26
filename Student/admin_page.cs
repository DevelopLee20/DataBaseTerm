using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class admin_page : Form
    {
        public admin_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            try{
                OleDbCommand cmd = new OleDbCommand();
                String query = $"INSERT INTO 학생 VALUES('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}')";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                MessageBox.Show("학생 등록 완료\n" + query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                String query = $"INSERT INTO 교수 VALUES('{textBox12.Text}', '{textBox11.Text}', '{textBox9.Text}', '{textBox7.Text}')";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                MessageBox.Show("교수 등록 완료\n" + query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                String query = $"INSERT INTO 과목 VALUES('{textBox16.Text}', '{textBox15.Text}', '{textBox14.Text}', '{textBox13.Text}', '{textBox10.Text}', '{textBox8.Text}', '{textBox17.Text}')";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                MessageBox.Show("과목 등록 완료\n" + query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                String query = $"INSERT INTO 개설과목 VALUES('{textBox21.Text}', '{textBox20.Text}', '{textBox19.Text}', '{textBox18.Text}', NULL)";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                MessageBox.Show("개설 과목 등록 완료\n" + query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }
        }
    }
}

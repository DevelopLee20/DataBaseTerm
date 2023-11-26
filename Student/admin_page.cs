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

            try // 전체 수강 명부
            {
                dataGridView2.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT * FROM 수강";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                int counts = 5;

                dataGridView2.ColumnCount = counts;

                for (int i = 0; i < counts; i++)
                {
                    dataGridView2.Columns[i].Name = read.GetName(i);
                }

                while (read.Read())
                {
                    object[] obj = new object[counts]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < counts; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView2.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }

                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                String query = $"DELETE FROM 수강 WHERE 과목번호 = '{textBox22.Text}' AND 학번='{textBox23.Text}'";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                MessageBox.Show("수강 취소 완료\n" + query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }

            try // 전체 수강 명부
            {
                dataGridView2.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT * FROM 수강";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                int counts = 5;

                dataGridView2.ColumnCount = counts;

                for (int i = 0; i < counts; i++)
                {
                    dataGridView2.Columns[i].Name = read.GetName(i);
                }

                while (read.Read())
                {
                    object[] obj = new object[counts]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < counts; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView2.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }

                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }
        }
    }
}

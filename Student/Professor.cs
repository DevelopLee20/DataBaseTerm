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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Student
{
    public partial class Professor : Form
    {
        public Professor()
        {
            InitializeComponent();

            label1.Text = label1.Text + main.number;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT * FROM 개설과목 WHERE 담당교수='{main.number}'";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                int counts = 5;

                dataGridView1.ColumnCount = counts;

                for(int i=0; i< counts; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }

                while (read.Read())
                {
                    object[] obj = new object[counts]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < counts; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }

                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }

            try // 내 수업 수강 명부
            {
                dataGridView2.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT * FROM 수강 WHERE 과목번호 IN (SELECT 과목번호 FROM 개설과목 WHERE 담당교수 = '{main.number}')";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                String query = $"UPDATE 개설과목 SET 교재='{textBox1.Text}' WHERE 과목번호='{textBox2.Text}'";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                MessageBox.Show("교재 등록 완료\n" + query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }

            try
            {
                dataGridView1.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT * FROM 개설과목 WHERE 담당교수='{main.number}'";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                int counts = 5;

                dataGridView1.ColumnCount = counts;

                for (int i = 0; i < counts; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }

                while (read.Read())
                {
                    object[] obj = new object[counts]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < counts; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }

                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.Text == "A" || textBox5.Text == "B" || textBox5.Text == "C" || textBox5.Text == "F")
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    String query = $"UPDATE 수강 SET 성적='{textBox5.Text}' WHERE 학번='{textBox3.Text}' AND 과목번호='{textBox4.Text}'";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                    OleDbConnection conn = new OleDbConnection(ConnectString);
                    conn.Open();
                    cmd.Connection = conn;

                    OleDbDataReader read = cmd.ExecuteReader();

                    MessageBox.Show("성적 등록 완료\n" + query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); //에러 메세지
                }

                try // 내 수업 수강 명부
                {
                    dataGridView2.Rows.Clear();
                    OleDbCommand cmd = new OleDbCommand();
                    String query = $"SELECT * FROM 수강 WHERE 과목번호 IN (SELECT 과목번호 FROM 개설과목 WHERE 담당교수 = '{main.number}')";
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
            else
            {
                MessageBox.Show("성적은 A, B, C, F 중 하나만 입력 가능합니다.");
            }
        }
    }
}

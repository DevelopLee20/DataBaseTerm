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
    public partial class Student_page : Form
    {
        public Student_page()
        {
            InitializeComponent();

            label1.Text = label1.Text + main.number;

            try // 수강신청 가능 목록
            {
                dataGridView1.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT 개설.* FROM 개설과목 개설 INNER JOIN 학생 학 ON 개설.담당교수 = 학.지도교수 INNER JOIN 과목 과 ON 개설.과목번호 = 과.과목번호 WHERE 학.학번 = '{main.number}' AND 학.학과이름 = 과.학과이름 AND 학.학년 = 과.대상학년";
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

            try // 수강신청한 목록 갱신
            {
                dataGridView2.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT * FROM 수강 WHERE 학번='{main.number}'";
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
                String query = $"INSERT INTO 수강 VALUES('{main.number}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', NULL)";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                String ConnectString = "Provider=MSDAORA;Password=123123;User ID=Term";
                OleDbConnection conn = new OleDbConnection(ConnectString);
                conn.Open();
                cmd.Connection = conn;

                OleDbDataReader read = cmd.ExecuteReader();

                MessageBox.Show("수강신청 완료 완료\n" + query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지
            }

            try // 수강신청한 목록 갱신
            {
                dataGridView2.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT * FROM 수강 WHERE 학번='{main.number}'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                String query = $"DELETE FROM 수강 WHERE 과목번호 = '{textBox1.Text}'";
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

            try // 수강신청한 목록 갱신
            {
                dataGridView2.Rows.Clear();
                OleDbCommand cmd = new OleDbCommand();
                String query = $"SELECT * FROM 수강 WHERE 학번='{main.number}'";
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        Database1Entities db;
        Department Department;
        Exam Exam;
        Subject Subject;
        Student Student;
        StudentMark StudentMark;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            db = new Database1Entities();
            dataGridView1.DataSource = db.Students.ToList();
            dataGridView2.DataSource = db.StudentMarks.ToList();
            dataGridView3.DataSource = db.SubjectLectures.ToList();
            LoadDept();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        public void LoadDept()
        {
            try
            {
                db = new Database1Entities();
                Department = new Department();
                var data = db.Departments.Select(x => x.Id.ToString()).ToList();
                comboBox1.Items.AddRange(data.ToArray());
            }
            catch { }

            try
            {
                db = new Database1Entities();
                Exam = new Exam();
                var data = db.Exams.Select(x => x.Id.ToString()).ToList();
                comboBox2.Items.AddRange(data.ToArray());
            }
            catch { }

            try
            {
                db = new Database1Entities();
                Subject = new Subject();
                var data = db.Subjects.Select(x => x.Id.ToString()).ToList();
                comboBox3.Items.AddRange(data.ToArray());
            }
            catch { }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                db = new Database1Entities();
                dataGridView1.DataSource = db.Students.ToList().FindAll(x => x.DepartmentId.ToString() == comboBox1.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                db = new Database1Entities();
                dataGridView2.DataSource = db.StudentMarks.ToList().FindAll(x => x.ExamId.ToString() == comboBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                db = new Database1Entities();
                dataGridView3.DataSource = db.SubjectLectures.ToList().FindAll(x => x.SubjectId.ToString() == comboBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

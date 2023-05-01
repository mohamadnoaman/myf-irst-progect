using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        Database1Entities db = new Database1Entities();
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            var item = db.Students.ToArray();
            foreach (var item1 in item)
            {
                domainUpDown1.Items.Add(item1.Id);
            }

            var item2 = db.Students.ToArray();
            foreach (var item3 in item2)
            {
                domainUpDown4.Items.Add(item3.Id);
            }

            var item4 = db.Exams.ToArray();
            foreach (var item5 in item4)
            {
                domainUpDown2.Items.Add(item5.Id);
            }

            var item6 = db.Exams.ToArray();
            foreach (var item7 in item6)
            {
                domainUpDown3.Items.Add(item7.Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.StudentMarks.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                StudentMark studentMark = new StudentMark { Mark = Convert.ToInt32(textBox2.Text), StudentId = Convert.ToInt32(domainUpDown1.Text), ExamId = Convert.ToInt32(domainUpDown3.Text) };
                db.StudentMarks.Add(studentMark);
                db.SaveChanges();
                MessageBox.Show("Added Complete");
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox3.Text);
                StudentMark studentMark = db.StudentMarks.SingleOrDefault(dep => dep.Id == id);
                if (studentMark != null)
                {
                    studentMark.StudentId = Convert.ToInt32(domainUpDown4.Text);
                    studentMark.Mark = Convert.ToInt32(textBox1.Text);
                    studentMark.ExamId = Convert.ToInt32(domainUpDown2.Text);
                    db.SaveChanges();
                    MessageBox.Show("Updated Complete");
                    textBox1.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("Note Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox5.Text);
                StudentMark studentMark = db.StudentMarks.SingleOrDefault(dep => dep.Id == id);
                if (studentMark != null)
                {
                    db.StudentMarks.Remove(studentMark);
                    db.SaveChanges();
                    MessageBox.Show("Deteted Complete");
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("Note Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown3_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown4_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}

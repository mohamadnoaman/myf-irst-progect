using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Database1Entities db = new Database1Entities();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                var item = db.Subjects.ToArray();
                foreach (var item1 in item)
                {
                    domainUpDown1.Items.Add(item1.Id);
                }

                var item2 = db.Subjects.ToArray();
                foreach (var item3 in item2)
                {
                    domainUpDown2.Items.Add(item3.Id);
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Exams.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Exam exam = new Exam { Date = dateTimePicker1.Value, Term = Convert.ToInt32(textBox1.Text), SubjectId = Convert.ToInt32(domainUpDown1.Text) };
                db.Exams.Add(exam);
                db.SaveChanges();
                MessageBox.Show("Added Complete");
                textBox1.Text = "";
                textBox2.Text = "";
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
                Exam exam = db.Exams.SingleOrDefault(dep => dep.Id == id);
                if (exam != null)
                {
                    db.Exams.Remove(exam);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox3.Text);
                Exam exam = db.Exams.SingleOrDefault(dep => dep.Id == id);
                if (exam != null)
                {
                    exam.Term = Convert.ToInt32(textBox2.Text);
                    exam.Date = dateTimePicker2.Value;
                    exam.SubjectId = Convert.ToInt32(domainUpDown2.Text);
                    db.SaveChanges();
                    MessageBox.Show("Updated Complete");
                    textBox2.Text = "";
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }   
}

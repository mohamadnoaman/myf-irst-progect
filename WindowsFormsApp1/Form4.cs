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
    public partial class Form4 : Form
    {
        Database1Entities db = new Database1Entities();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        private void Form4_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.SubjectLectures.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                SubjectLecture subjectLecture = new SubjectLecture { Title = textBox1.Text, Content = textBox2.Text, SubjectId = Convert.ToInt32(domainUpDown1.Text) };
                db.SubjectLectures.Add(subjectLecture);
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
                SubjectLecture subjectLecture = db.SubjectLectures.SingleOrDefault(dep => dep.Id == id);
                if (subjectLecture != null)
                {
                    db.SubjectLectures.Remove(subjectLecture);
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
                SubjectLecture subjectLecture = db.SubjectLectures.SingleOrDefault(dep => dep.Id == id);
                if (subjectLecture != null)
                {
                    subjectLecture.Title = textBox4.Text;
                    subjectLecture.Content = textBox6.Text;
                    subjectLecture.SubjectId = Convert.ToInt32(domainUpDown2.Text);
                    db.SaveChanges();
                    MessageBox.Show("Updated Complete");
                    textBox6.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox6.Text = "";

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
    }
}

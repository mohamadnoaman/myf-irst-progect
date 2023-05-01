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
    public partial class Form3 : Form
    {
        Database1Entities db = new Database1Entities();

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var item = db.Departments.ToArray();
            foreach (var item1 in item)
            {
                domainUpDown1.Items.Add(item1.Id);
            }

            var item2 = db.Departments.ToArray();
            foreach (var item3 in item2)
            {
                domainUpDown2.Items.Add(item3.Id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Subjects.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Subject subject = new Subject { Name = textBox1.Text, Term = Convert.ToInt32(textBox2.Text), Year = Convert.ToInt32(textBox3.Text), MinimumDegree = Convert.ToInt32(textBox4.Text), DepartmentId = Convert.ToInt32(domainUpDown1.Text) };
                db.Subjects.Add(subject);
                db.SaveChanges();
                MessageBox.Show("Added Complete");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
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
                Subject subject = db.Subjects.SingleOrDefault(dep => dep.Id == id);
                if (subject != null)
                {
                    db.Subjects.Remove(subject);
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
                int id = int.Parse(textBox6.Text);
                Subject subject = db.Subjects.SingleOrDefault(dep => dep.Id == id);
                if (subject != null)
                {
                    subject.Name = textBox7.Text;
                    subject.Term = Convert.ToInt32(textBox8.Text);
                    subject.Year = Convert.ToInt32(textBox9.Text);
                    subject.MinimumDegree = Convert.ToInt32(textBox10.Text);
                    subject.DepartmentId = Convert.ToInt32(domainUpDown2.Text);
                    db.SaveChanges();
                    MessageBox.Show("Updated Complete");
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

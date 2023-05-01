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
    public partial class Form6 : Form
    {
        Database1Entities db = new Database1Entities();

        public Form6()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
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
            dataGridView1.DataSource = db.Students.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student { UserName = textBox1.Text, Email = textBox2.Text, Phone = textBox3.Text, RegisterDate = dateTimePicker1.Value , DepartmentId = Convert.ToInt32(domainUpDown1.Text) };
                db.Students.Add(student);
                db.SaveChanges();
                MessageBox.Show("Added Complete");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
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
                Student student = db.Students.SingleOrDefault(dep => dep.Id == id);
                if (student != null)
                {
                    student.UserName = textBox7.Text;
                    student.Email = textBox8.Text;
                    student.Phone = textBox9.Text;
                    student.RegisterDate = dateTimePicker2.Value;
                    student.DepartmentId = Convert.ToInt32(domainUpDown2.Text);
                    db.SaveChanges();
                    MessageBox.Show("Updated Complete");
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
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
                Student student = db.Students.SingleOrDefault(dep => dep.Id == id);
                if (student != null)
                {
                    db.Students.Remove(student);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
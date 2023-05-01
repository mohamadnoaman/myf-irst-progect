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
    public partial class Form7 : Form
    {

        Database1Entities db = new Database1Entities();

        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Departments.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Department department = new Department { Name = textBox1.Text };
                db.Departments.Add(department);
                db.SaveChanges();
                MessageBox.Show("Added Complete");
                textBox1.Text = "";
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
                int id = int.Parse(textBox2.Text);
                Department department = db.Departments.SingleOrDefault(dep => dep.Id == id);
                if (department != null)
                {
                    db.Departments.Remove(department);
                    db.SaveChanges();
                    MessageBox.Show("Deteted Complete");
                    textBox2.Text = "";
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
                Department department = db.Departments.SingleOrDefault(dep => dep.Id == id);
                if (department != null)
                {
                    department.Name = textBox4.Text;
                    db.SaveChanges();
                    MessageBox.Show("Updated Complete");
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

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}

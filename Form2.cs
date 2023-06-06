using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrame
{
    public partial class Form2 : Form
    {
        autoAutoEntities db = new autoAutoEntities();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Korzinas.ToList<Korzina>();
            dataGridView2.DataSource = db.Customerses.ToList<Customers>();
            dataGridView3.DataSource = db.Orderses.ToList<Orders>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = dataGridView2.CurrentRow;
            int TovarID = (int)curRow.Cells["Id"].Value;

            // Берем ссылку на текущую запись
            Customers tovar = db.Customerses.Find(TovarID);
            db.Customerses.Remove(tovar);
            db.SaveChanges();

            // В dataGridView2 отображаем новых данных
            dataGridView2.DataSource = db.Customerses.ToList<Customers>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = dataGridView3.CurrentRow;
            int TovarID = (int)curRow.Cells["Id"].Value;

            // Берем ссылку на текущую запись
            Orders tovar = db.Orderses.Find(TovarID);
            db.Orderses.Remove(tovar);
            db.SaveChanges();

            // В dataGridView2 отображаем новых данных
            dataGridView3.DataSource = db.Orderses.ToList<Orders>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customers custom = new Customers()
            {
                Id = Convert.ToInt32(textBox2.Text),
                CustomerName = textBox1.Text
            };

            db.Customerses.Add(custom);
            db.SaveChanges();

            // Вывод измененных данных
            dataGridView2.DataSource = db.Customerses.ToList<Customers>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int TovarID, TovarNameId, Kol;
            string Price, CustomerName;

            DataGridViewRow curRow = dataGridView1.CurrentRow;
            TovarID = (int)curRow.Cells["Id"].Value;
            TovarNameId = (int)curRow.Cells["NameId"].Value;
            Price = curRow.Cells["Cost"].Value.ToString();
            Kol = (int)curRow.Cells["Kol"].Value;

            DataGridViewRow curRow1 = dataGridView2.CurrentRow;
            CustomerName = curRow1.Cells["CustomerName"].Value.ToString();


            Orders tovar = new Orders();
            tovar.Id = TovarID;
            tovar.CustomerName = CustomerName;
            tovar.DetailNameId = TovarNameId;
            tovar.Cost = (int?)Convert.ToDecimal(Price);
            tovar.Kol = Kol;
            //TovarID++;

            
            db.Orderses.Add(tovar);
            db.SaveChanges();


            // В dataGridView2 отображаем новых данных
            dataGridView3.DataSource = db.Orderses.ToList<Orders>();


            //Customers_2 custom = new Customers_2();
            //custom.Id = TovarID;
            //custom.Name = CustomerName;
            //custom.DetailNameId = TovarNameId;
            //custom.Cost = (int?)Convert.ToDecimal(Price);
            //custom.Kol = Kol;

            //db.Customers_2s.Add(custom);
            //db.SaveChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (0 == 0)
            {
                Form3 form3 = new Form3();
                form3.Show();

            }
            else
            {
                MessageBox.Show("Нет инфомации о покупателе");
            }
        }
    }
}

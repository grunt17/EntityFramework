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
    public partial class Form3 : Form
    {
        autoAutoEntities db = new autoAutoEntities();
        string detName;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customers_2s.ToList<Customers_2>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = dataGridView1.CurrentRow;
            int TovarID = (int)curRow.Cells["Id"].Value;

            // Берем ссылку на текущую запись
            Customers_2 tovar = db.Customers_2s.Find(TovarID);
            db.Customers_2s.Remove(tovar);
            db.SaveChanges();

            // В dataGridView2 отображаем новых данных
            dataGridView1.DataSource = db.Customers_2s.ToList<Customers_2>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Customers_2 detType = db.Customers_2s.FirstOrDefault(
            //                                 d => d.Name == comboBox1.Text);
            //detName = detType.Name;
            //var TovarsByDevID = db.Customerses.Where(t => t.CustomerName == detName);
            //dataGridView1.DataSource = TovarsByDevID.ToList<Customers>();
        }
    }
}

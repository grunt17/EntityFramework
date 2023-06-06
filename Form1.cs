using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EntityFrame
{
    public partial class Form1 : Form
    {
        autoAutoEntities db = new autoAutoEntities();

        int detID;
        int marksID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Detailsses.ToList<Detailss>();
            dataGridView2.DataSource = db.Korzinas.ToList<Korzina>();

            //===========================================================================
            // Заполнение comboBox1
            comboBox1.Items.Add("Все категория");
            comboBox1.Text = "Все категория";
            foreach (var device in db.DetailTypes)
            {
                comboBox1.Items.Add(device.DetailTypeName.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int TovarID, TovarNameId;
            string Price;

            DataGridViewRow curRow = dataGridView1.CurrentRow;
            TovarID = (int)curRow.Cells["DetailId"].Value;
            TovarNameId = (int)curRow.Cells["DetailNameId"].Value;
            Price = curRow.Cells["Cost"].Value.ToString();


            Korzina tovar = new Korzina();
            tovar.Id = TovarID;
            tovar.NameId = TovarNameId;
            tovar.Cost = (int?)Convert.ToDecimal(Price);
            tovar.Kol = Convert.ToInt32(textBox1.Text);


            db.Korzinas.Add(tovar);
            db.SaveChanges();

            // В dataGridView2 отображаем новых данных
            dataGridView2.DataSource = db.Korzinas.ToList<Korzina>();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = dataGridView2.CurrentRow;
            int TovarID = (int)curRow.Cells["Id"].Value;

            // Берем ссылку на текущую запись
            Korzina tovar = db.Korzinas.Find(TovarID);
            db.Korzinas.Remove(tovar);
            db.SaveChanges();

            // В dataGridView2 отображаем новых данных
            dataGridView2.DataSource = db.Korzinas.ToList<Korzina>();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index == 0) // Если выбраны все типы устройств
            {
                dataGridView1.DataSource = db.Detailsses.ToList<Detailss>();
            }
            else  // Если выбран конкретный тип устройства
            {
                DetailType detType = db.DetailTypes.FirstOrDefault(
                                            d => d.DetailTypeName == comboBox1.Text);
                detID = detType.DetailTypeId;
                var TovarsByDevID = db.Detailsses.Where(t => t.DetailTypeId == detID);
                dataGridView1.DataSource = TovarsByDevID.ToList<Detailss>();
            }
            
            //Заполнение списка comboBox2
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Все машины");
            comboBox2.Text = "Все машины";
            comboBox2.Visible = true;

            foreach (var firm in db.Markas)
            {
                comboBox2.Items.Add(firm.MarkaName.ToString());
            }
            //Четко работает, не трогать больше!
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox2.SelectedIndex;

            if (index == 0) // Если выбраны все фирмы-производители
            {
                var TovarsByDevID = db.Detailsses.Where(t => t.DetailTypeId == detID);
                dataGridView1.DataSource = TovarsByDevID.ToList<Detailss>();
            }
            else // Если выбрана конкретная фирма-производитель                 
            {
                // Выбор фирмы по имени фирмы
                Marka marka = db.Markas.FirstOrDefault(
                                         f => f.MarkaName == comboBox2.Text);
                int markaID = marka.MarkaId;
                marksID = marka.MarkaId;

                //Выбор товаров по номеру устройства и фирмы
                var TovarsSelected = db.Detailsses.Where(
                                       t => t.DetailTypeId == detID & t.MarkaId == markaID);
                dataGridView1.DataSource = TovarsSelected.ToList<Detailss>();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}


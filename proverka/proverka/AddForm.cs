using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proverka
{
    public partial class AddForm : Form
    {
        DataBase database = new DataBase();

        public AddForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();
            
           
           int id_ready_item;
           var id_supply = textBox3.Text;
           var quantity_used = textBox4.Text;

            if (int.TryParse(textBox2.Text, out id_ready_item)) 
            {
                var addQuery = $"insert into ИспользованныеМатериалы (id_ready_item, id_supply, quantity_used) values ('{id_ready_item}', '{id_supply}', '{quantity_used}')";  
                
                var command = new SqlCommand (addQuery, database.getConnection());
                command.ExecuteNonQuery ();

                MessageBox.Show("Добавлен Дима Масленников", "Красава!", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else 
            {
                MessageBox.Show("Балван адо числа вводить", "Балван!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            database.closeConnection();


        }

        
    }
}

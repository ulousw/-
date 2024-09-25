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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class EmployeePanel : Form


    {
        DataBase database = new DataBase();

        private string connectionString = "Data Source=DESKTOP-DLQ4A54\\SQLEXPRESS02;Initial Catalog=CLEAN;Integrated Security=True;Encrypt=False;";

        int selectedRow;

        public EmployeePanel()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_used_supply", "id_used_supply");
            dataGridView1.Columns.Add("id_ready_item", "id_ready_item");
            dataGridView1.Columns.Add("id_supply", "id_supply");
            dataGridView1.Columns.Add("quantity_used", "quantity_used");
            dataGridView1.Columns.Add("RowState", "RowState");  // Дополнительный столбец для хранения состояния строки
        }


        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            int id_used_supply = record.IsDBNull(0) ? 0 : record.GetInt32(0);
            string id_ready_item = record.IsDBNull(1) ? string.Empty : record.GetValue(1).ToString();
            string id_supply = record.IsDBNull(2) ? string.Empty : record.GetValue(2).ToString();
            string quantity_used = record.IsDBNull(3) ? string.Empty : record.GetValue(3).ToString();

            dgw.Rows.Add(id_used_supply, id_ready_item, id_supply, quantity_used, RowState.ModifiedNew); // Добавляем RowState в последний столбец
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from ИспользованныеМатериалы";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"select * from ИспользованныеМатериалы";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReadSingleRow(dgw, reader);
                        }
                    }
                }
            }
        }

        private void EmployeePanel_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();


            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        

        private void deleteRow() 
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty) 
            {
                dataGridView1.Rows[index].Cells[4].Value = RowState.Deleted;
            }
        }

        private void Update()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                if (dataGridView1.Rows[index].Cells[4].Value != null &&
                    dataGridView1.Rows[index].Cells[4].Value is RowState rowState)
                {
                    if (rowState == RowState.Existed)
                        continue;

                    if (rowState == RowState.Deleted)
                    {
                        var id_used_supply = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from ИспользованныеМатериалы where id_used_supply = {id_used_supply}";

                        var command = new SqlCommand(deleteQuery, database.getConnection());
                        command.ExecuteNonQuery();
                    }
                    if (rowState == RowState.ModifiedNew)
                    {
                        var id_used_supply = dataGridView1.Rows[index].Cells[0].Value.ToString();
                        var id_ready_item = dataGridView1.Rows[index].Cells[1].Value.ToString();
                        var id_supply = dataGridView1.Rows[index].Cells[2].Value.ToString();
                        var quantity_used = dataGridView1.Rows[index].Cells[3].Value.ToString();

                        var changeQuery = $"update ИспользованныеМатериалы set id_ready_item = '{id_ready_item}', id_supply = '{id_supply}', quantity_used = '{quantity_used}' where id_used_supply = '{id_used_supply}'";

                        var command = new SqlCommand (changeQuery, database.getConnection());

                        command.ExecuteNonQuery();
                    }

                }
            }

            database.closeConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update();

            RefreshDataGrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var id_used_supply = textBox1.Text;
            int id_ready_item;
            var id_supply = textBox3.Text;
            var quantity_used = textBox4.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty) 
            {
                
                if (int.TryParse(textBox2.Text, out id_ready_item))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id_used_supply, id_ready_item, id_supply, quantity_used);
                    dataGridView1.Rows[selectedRowIndex].Cells[4].Value = RowState.ModifiedNew;
                }
                else
                {
                    MessageBox.Show("НУ ты щавель реально, надо цифровой формат");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }







}

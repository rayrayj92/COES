using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace COES
{
    public partial class Form1 : Form
    {
        private crudVO cruds;
        private Int32 catchRowIndex;

        public String test1;
        public String test2;
        public String test3;

        Int32 count = 0;
        Int32 count_total = 0;

        double cost = 0;
        double cost_total = 0;

        private void SetupDataGridView() {
            this.Controls.Add(dataGridView1);
        }
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Take-Away");
            comboBox1.Items.Add("Home Delivery");
            //Disable complete button
            button7.Enabled = false;
            textBox13.PasswordChar = '*';
        }
        //Calculate the total of cost
        public void calculateTotal()
        {
            double sum = 0;
            double sub = 0;
            int quantity = 0;
            double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sub = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                total = (sub * quantity);
                sum += total;
            }
            rdSum.Text = sum.ToString("###,###,###,#00.00");
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
        }
        //Update item
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cruds = new crudVO();
                cruds.itemid = Convert.ToInt32(textBox11.Text);
                cruds.itemname = textBox5.Text;
                cruds.itemcost = Convert.ToDouble(textBox4.Text);
                cruds.quantity = Convert.ToInt32(textBox3.Text);
                cruds.Update();

                dataGridView1[0, catchRowIndex].Value = textBox5.Text;
                dataGridView1[1, catchRowIndex].Value = textBox4.Text;
                dataGridView1[2, catchRowIndex].Value = textBox3.Text;

                textBox5.Clear();
                textBox4.Clear();
                textBox3.Clear();
                textBox11.Clear();

                calculateTotal();

            }
            finally
            { 
                
            }
        }
        //Add item
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cruds = new crudVO();
                cruds.itemname = textBox5.Text;
                cruds.itemcost = Convert.ToDouble(textBox4.Text);
                cruds.quantity = Convert.ToInt32(textBox3.Text);
                cruds.orderid = Convert.ToInt32(textBox9.Text);
                cruds.Insert();

                dataGridView1.Rows.Add(textBox5.Text, textBox4.Text, textBox3.Text);
                textBox5.Clear();
                textBox4.Clear();
                textBox3.Clear();

                calculateTotal();
            }
            catch (Exception)
            {
                MessageBox.Show("Problem", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Delete item
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cruds = new crudVO();
                cruds.itemid = Convert.ToInt32(textBox11.Text);
                cruds.Delete();
                dataGridView1.Rows.RemoveAt(catchRowIndex);

                calculateTotal();
            }
            catch (Exception)
            {
                MessageBox.Show("Problem", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Refresh button
        private void button4_Click(object sender, EventArgs e)
        {
            calculateTotal();
        }
        //Calculate which row is selected
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catchRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox5.Text = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        //Insert customer's information
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                cruds = new crudVO();
                cruds.customername = textBox8.Text;
                cruds.customeraddress = textBox1.Text;
                cruds.customerphone = Convert.ToInt32(textBox2.Text);
                cruds.customerID = Convert.ToInt32(textBox10.Text);
                cruds.ordertype = comboBox1.Text;
                cruds.InsertCustomer();

                textBox8.Clear();
                textBox1.Clear();
                textBox2.Clear();

                MessageBox.Show("Done", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Problem", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Item name
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        //Item cost
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //Item Quantity
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdSum_TextChanged(object sender, EventArgs e)
        {

        }
        //Complete the order.
        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                cruds = new crudVO();
                cruds.orderid = Convert.ToInt32(textBox9.Text);
                cruds.customerID = Convert.ToInt32(textBox10.Text);
                cruds.totalcost = Convert.ToDouble(rdSum.Text);

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd MM yyyy";

                cruds.orderdate = Convert.ToDateTime(this.dateTimePicker1.Text);
                cruds.completeOrder();

                textBox1.Clear();
                textBox2.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();

                dataGridView1.Rows.Clear();
                calculateTotal();

                button6.Enabled = false;
                checkBox1.Checked = false;
                label15.Text = "New";
            }
            catch (Exception)
            {
                MessageBox.Show("Problem", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        //Calucatle Summary
        private void button7_Click(object sender, EventArgs e)
        {
            // Clear the row before getting new data rows
            dataGridView2.Rows.Clear();
            // Set number 0 for total cost and total number of orders
            count = 0;
            cost = 0;
            count_total = 0;
            cost_total = 0;
            // Connection between MySQL and C#
            string myConnection = "Server=localhost;Database=db_coes;port=3306;username=root;password=fnsl21";
            MySqlConnection conn = new MySqlConnection(myConnection);
            String query = "SELECT orderdate, COUNT(*), sum(totalcost) FROM db_coes.orders GROUP BY orderdate";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while(dataReader.Read())
                {
                    test1 = dataReader["orderdate"].ToString();
                    test2 = dataReader["COUNT(*)"].ToString();
                    test3 = dataReader["sum(totalcost)"].ToString();

                    dataGridView2.Rows.Add(test1, test2, test3);

                    count = Convert.ToInt32(test2);
                    count_total += count;

                    cost = Convert.ToDouble(test3);
                    cost_total += cost;

                    textBox7.Text = count_total.ToString();
                    textBox6.Text = cost_total.ToString("###,###,###,#00.00");
                }
                cmd.Dispose();
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        // Payment Status
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button6.Enabled = true;
            label15.Text = "Paid";
        }
        // Only available for a manager
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "admin" && textBox13.Text == "123")
            {
                button7.Enabled = true;
                textBox12.Clear();
                textBox13.Clear();
            }
        }

    }
}

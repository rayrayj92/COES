using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES
{
    class crudDAO
    {
        //Connection between MySQL and C#
        string myConnection = "Server=localhost;Database=db_coes;port=3306;username=root;password=fnsl21";
        public crudDAO() 
        {
 
        }
        public void InsertData(String itemname, Double itemcost, Int32 quantity, Int32 orderid)
        {
            
            MySqlConnection conn = new MySqlConnection(myConnection);

            String query = "INSERT INTO items (itemname, itemcost, quantity, orderid) VALUES (?itemname, ?itemcost, ?quantity, ?orderid)";

            try{
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?itemname", itemname);
                cmd.Parameters.AddWithValue("?itemcost", itemcost);
                cmd.Parameters.AddWithValue("?quantity", quantity);
                cmd.Parameters.AddWithValue("?orderid", orderid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally{
                conn.Close();
            }

        }

        public void InsertCustomer(Int32 id, String ordertype, String name, String address, Int32 phone)
        {
            MySqlConnection conn = new MySqlConnection(myConnection);

            String query = "INSERT INTO customers (customerID, address, phone, ordertype, name) VALUES (?customerID, ?address, ?phone, ?ordertype, ?name)";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?customerID", id);
                cmd.Parameters.AddWithValue("?address", address);
                cmd.Parameters.AddWithValue("?phone", phone);
                cmd.Parameters.AddWithValue("?ordertype", ordertype);
                cmd.Parameters.AddWithValue("?name", name);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                conn.Close();
            }
        }

        public void CompleteData(Int32 orderid, Int32 customerID, DateTime orderdate, Double totalcost)
        {
            MySqlConnection conn = new MySqlConnection(myConnection);

            String query1 = "INSERT INTO orders (orderid, customerID, orderdate, totalcost) VALUES (?orderid, ?customerID, ?orderdate, ?totalcost)";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query1, conn);
                cmd.Parameters.AddWithValue("?orderid", orderid);
                cmd.Parameters.AddWithValue("?customerID", customerID);
                cmd.Parameters.AddWithValue("?orderdate", orderdate);
                cmd.Parameters.AddWithValue("?totalcost", totalcost);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateData(Int32 id, String name, Double cost, Int32 quantity)
        {
            MySqlConnection conn = new MySqlConnection(myConnection);

            String query = "UPDATE items SET itemname = ?itemname, itemcost = ?itemcost, quantity = ?quantity";
            query += " WHERE itemid = ?itemid";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?itemname", name);
                cmd.Parameters.AddWithValue("?itemcost", cost);
                cmd.Parameters.AddWithValue("?quantity", quantity);
                cmd.Parameters.AddWithValue("?itemid", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                conn.Close();
            }

        }

        public void DeleteData(Int32 id)
        {
            MySqlConnection conn = new MySqlConnection(myConnection);

            String query = "DELETE FROM items ";
            query += "WHERE itemid = ?itemid";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?itemid", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

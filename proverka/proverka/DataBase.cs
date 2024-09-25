using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace proverka
{
    internal class DataBase
    {
        SqlConnection SqlConnection = new SqlConnection(@"Data Source=DESKTOP-DLQ4A54\SQLEXPRESS02;Initial Catalog=CLEAN;Integrated Security=True;Encrypt=False");

        public void openConnection() 
        { 
            if (SqlConnection.State == System.Data.ConnectionState.Closed) 
            { 
                SqlConnection.Open();
            }

        }

        public void closeConnection() 
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open) 
            { 
                SqlConnection.Close();
            }
        }

        public SqlConnection getConnection() 
        { 
            return SqlConnection;
        }
       
    }
}

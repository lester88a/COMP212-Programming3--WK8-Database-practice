using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FirstDBPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlDataReader sqlDataReader = null;

            //1. Instantiating the connection
            SqlConnection SqlConnection = new SqlConnection("data source=THINKPAD-PC;initial catalog=northwind;Integrated Security=true");

           
            try
            {
                //2. opening the connection
                SqlConnection.Open();

                //3. pass the connection to a command object
                SqlCommand sqlCommand = new SqlCommand("Select * from customers", SqlConnection);

                //4. retrieve the query results to the help of a reader
                sqlDataReader = sqlCommand.ExecuteReader();

               // Console.WriteLine("[CompanyName]\t[ContactName]\t[ContactTitle]\t[Address]\t[City]\t[Region]\t[PostalCode]\t[Country]");
                Console.WriteLine("[CompanyName]\t[ContactName]");

                while (sqlDataReader.Read())
                {
                    //Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",sqlDataReader[0],sqlDataReader[1],sqlDataReader[2],sqlDataReader[3],sqlDataReader[4],sqlDataReader[5],sqlDataReader[6],sqlDataReader[7]);
                    Console.WriteLine("{0}\t{1}",sqlDataReader[0],sqlDataReader[1]);

                    //Console.WriteLine(sqlDataReader[1]);
                }
            }
            finally
            {
                
                //close the reader
                if (sqlDataReader!=null)
                {
                    sqlDataReader.Close();
                }
                if (SqlConnection!=null)
                {
                    SqlConnection.Close();
                }
                Console.ReadKey();
            }
        }

    }
}

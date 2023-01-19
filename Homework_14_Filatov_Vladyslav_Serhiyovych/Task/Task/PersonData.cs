using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class PersonData
    {
        SqlConnection sqlConnection;
        public PersonData(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Insert(string id, string firstName, string lastName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Person (PersonId, FirstName, LastName)" +
                $" VALUES ('{id}', '{firstName}', '{lastName}')", sqlConnection);
                sqlConnection.Open(); 
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Update(string id, string firstName, string lastName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Person " +
                    $"SET FirstName = '{firstName}', LastName = '{lastName}' " +
                    $"WHERE PersonId = '{id}'", sqlConnection);
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Read()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Person", sqlConnection);
                sqlConnection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader["FirstName"]} {dataReader["LastName"]}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void Delete(string personId)
        {           
            try
            {
                SqlCommand cm = new SqlCommand($"delete from person where personid = '{personId}'", sqlConnection);
                sqlConnection.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine($"{personId} deleted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong" + e);
            }
            
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}

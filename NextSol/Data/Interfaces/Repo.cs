using NextSol.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using NextSol.Data;

namespace NextSol.Data.Repository
{
    public class Repo<T> : IRepository<T> where T : class
    {
        SqlConnection connection;
        public T FindByID(string query)
        {
            using (connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();
                return connection.Query<T>(query).FirstOrDefault();
            }
        }
        public IEnumerable<T> GetAllData(string query)
        {
            using (connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();
                return connection.Query<T>(query).ToList();
            }
        }
        public int GetMaxId(string query)
        {
            using (connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();
                return connection.Query<int>(query).FirstOrDefault();
            }
            //throw new NotImplementedException();
        }
        public string GetName(string query)
        {
            using (connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();
                return connection.Query<string>(query).FirstOrDefault();
            }
            //throw new NotImplementedException();
        }
        public decimal GetNumber(string query)
        {
            using (connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();
                return connection.Query<decimal>(query).FirstOrDefault();
            }
            //throw new NotImplementedException();
        }

        public void Save(string query)
        {
            using (connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();
                connection.Query<T>(query);
            }
        }


        public void Update(string query)
        {
            using (connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();
                connection.Query<T>(query);
            }
        }

        public void Delete(string query)
        {
            using (connection = new SqlConnection(DBHelper.ConnectionString))
            {
                connection.Open();
                connection.Query<T>(query);
            }
        }
    }
}

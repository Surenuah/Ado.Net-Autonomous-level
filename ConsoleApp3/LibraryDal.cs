using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp3
{
    public class LibraryDal
    {
        private const string CONNECTIONSTRING = "Data Source=N205-13;Initial Catalog=Library;Integrated Security=True";

        private string _tableName;
        private string _query;
        public DataSet DataSet { get; }
        public LibraryDal(string tableName)
        {
            _tableName = tableName;
            _query = string.Format("select * from {0}", _tableName);
            DataSet = new DataSet();
            LoadData();
        }

        public void UpdateDatabase()
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                var sqlAdapter = new SqlDataAdapter(string.Format(_query, _tableName), connection);
                var sqlCommandBuilder = new SqlCommandBuilder(sqlAdapter);

                Console.WriteLine(sqlCommandBuilder.GetInsertCommand().CommandText);
                Console.WriteLine(sqlCommandBuilder.GetDeleteCommand().CommandText);
                Console.WriteLine(sqlCommandBuilder.GetUpdateCommand().CommandText);


                sqlAdapter.Update(DataSet);
            }
        }

        private DataSet LoadData()
        {
            // 1. Формирование строки запроса

            // 2. Открытие подключения к базе данных
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    connection.Open();

                    // 3. Создание объекта SqlDataAdapter
                    var sqlDataAdapter = new SqlDataAdapter(_query, connection);

                    // 4. Насыщение объекта типа DataSet
                    sqlDataAdapter.Fill(DataSet);
                    return DataSet;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return DataSet;
        }

        //public static DataSet GetAuthorById(DataSet dataSet, int authorId)
        //{
        //    string sqlQuery = string.Format("GetAuthorsNameById");

        //    using (var connection = new SqlConnection(CONNECTIONSTRING))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            var sqlCommand = new SqlCommand(sqlQuery, connection);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Parameters.Add(new SqlParameter("@Id", authorId));

        //            var adapter = new SqlDataAdapter(sqlCommand);
        //            adapter.Fill(dataSet);
        //        }
        //        catch(Exception exception)
        //        {
        //            Console.WriteLine(exception.Message);
        //        }
        //        return dataSet;
        //    }
        //}
    }
}

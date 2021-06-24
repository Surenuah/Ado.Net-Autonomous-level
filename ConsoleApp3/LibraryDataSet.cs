using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleApp3
{
    public class LibraryDataSet
    {
        public static DataSet CreateDataSet()
        {
            var dataset = new DataSet();

            dataset.ExtendedProperties.Add("DataBase owner", "Surenuah");
            dataset.ExtendedProperties.Add("Data Creation", DateTime.Now);
            dataset.ExtendedProperties.Add("Version", "V1");

            return dataset;
        }

        public static DataSet CreateTables(DataSet ds)
        {
            // 1. Создание таблицы 
            var dataTable = new DataTable("Authors");

            // 2. Создание колонок в таблицу
            var idColumn = new DataColumn("AuthorID", typeof(int))
            {
                AutoIncrement = true,
                AutoIncrementSeed = 0,
                AutoIncrementStep = 1,
                AllowDBNull = false
            };

            var nameColumn = new DataColumn("Name", typeof(string))
            {
                AllowDBNull = false,
                MaxLength = 100
            };

            // 3. Добавление колонок в таблицу
            dataTable.Columns.AddRange(new DataColumn[] { idColumn, nameColumn });
            
            // 4. Определение первичного ключа
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };

            // 5. Создаем данные
            var dataRow = dataTable.NewRow();
            dataRow["Name"] = "Surenuah";

            var dataRow1 = dataTable.NewRow();
            dataRow1["Name"] = "Surenuah";

            var dataRow2 = dataTable.NewRow();
            dataRow2["Name"] = "Surenuah";

            var dataRow3 = dataTable.NewRow();
            dataRow3["Name"] = "Surenuah";

            // 6. Добавляем данные
            dataTable.Rows.Add(dataRow);
            dataTable.Rows.Add(dataRow1);
            dataTable.Rows.Add(dataRow2);
            dataTable.Rows.Add(dataRow3);

            // 7. Добавляем таблицу в DataSet
            ds.Tables.Add(dataTable);
            return ds;
        }

        public static void ShowData(DataSet ds)
        {
            foreach (var table in ds.Tables)
            {
                var tb = (DataTable)table;
                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    Console.Write(tb.Columns[i] + "\t");
                }

                Console.WriteLine();

                for (int j = 0; j < tb.Rows.Count; j++)
                {
                    Console.WriteLine();
                    for (int k = 0; k < tb.Columns.Count; k++)
                    {
                        Console.Write(tb.Rows[j].ItemArray[k] + "\t");
                    }
                }
            }
        }

        public static void ShowDataByDataTableReader(DataTable dataTable)
        {
            var dataReader = new DataTableReader(dataTable);

            while (dataReader.Read())
            {
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    Console.WriteLine("\t{0}", dataReader.GetValue(i).ToString());
                }
                Console.WriteLine();
            }
        }

    }
}

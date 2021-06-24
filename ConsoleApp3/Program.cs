using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Создать объект DataSet
            //var dataSet = LibraryDataSet.CreateDataSet();

            //LibraryDal.LoadData(dataSet, "Authors");
            // 2. Передали объект DataSet для создания таблиц
            //LibraryDataSet.CreateTables(dataSet);

            //LibraryDal.GetAuthorById(dataSet, 4);

            // 3. Вывести данные из таблицы
            //LibraryDataSet.ShowDataByDataTableReader(dataSet.Tables[0]);

            var library = new LibraryDal("Authors");

            var authorTable = library.DataSet.Tables[0];

            var authorRow = authorTable.NewRow();
            authorRow["FullName"] = "Ergali Nuriden";

            authorTable.Rows.Add(authorRow);

            library.UpdateDatabase();

            //LibraryDataSet.ShowData(library.DataSet);
        }
    }
}

/*
Пример порождающего шаблона проектирования программ «Одиночка»,
который гарантирует, что в приложении будет создан единственный
экземпляр некоторого класса и предоставляет глобальную точку доступа
к этому экземпляру
*/

namespace Pattent_Singleton
{
    public class DatabaseHelper
    {
        private string? data;
        private static DatabaseHelper? databaseConnection;

        private DatabaseHelper() => Console.WriteLine("Connection to Database");
        public static DatabaseHelper GetConnection()
        {
            if (databaseConnection == null)
                databaseConnection = new DatabaseHelper();
            return databaseConnection;
        }

        public string? SelectData() => data;
        public void InsertData(string data)
        {
            Console.WriteLine($"New data: {data}, insert to Database" );
            this.data = data;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //var connection = new DatabaseHelper();
            DatabaseHelper.GetConnection().InsertData("12312");

            Console.WriteLine($"Selected data: {DatabaseHelper.GetConnection().SelectData()}");

            Console.ReadKey();
        }
    }
}

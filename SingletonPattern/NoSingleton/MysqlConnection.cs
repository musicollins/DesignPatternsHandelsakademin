using System;

namespace SingletonPattern
{
    //dependency class
    public class MysqlConnection
    {
        public string DbName { get; private set; }

        public MysqlConnection(string dbName)
        {
            DbName = dbName;
            Console.WriteLine($"Database connection {DbName} oppened");
        }

        public void someDbMethod()
        {
            Console.WriteLine($"Method call on => {DbName}");
        }

    }
}

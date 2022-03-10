using System;

namespace SingletonPattern
{
    public class MysqlConnection_SINGLETON
    {
        private static MysqlConnection_SINGLETON mysqlconn = new MysqlConnection_SINGLETON("mysqlConnection");
        public string DbName { get; private set; }
        public MysqlConnection_SINGLETON(string dbName)
        {
            DbName = dbName;
            Console.WriteLine($"Database connection {DbName} oppened");
            
        }
        public void someDbMethod()
        {
            Console.WriteLine($"Method call on => {DbName}");
        }
        public static MysqlConnection_SINGLETON getInstance()
        {
            return mysqlconn;
        }
    }
}

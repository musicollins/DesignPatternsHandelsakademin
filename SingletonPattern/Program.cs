using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MysqlConnection mysqlConnection = new MysqlConnection("MysqlDataBase");
            ClassOneNeedsMysqlConnection client1 = new ClassOneNeedsMysqlConnection(mysqlConnection);
        }
    }

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

    //client class
    public class ClassOneNeedsMysqlConnection
    {
        public string Name { get; private set; }
        private MysqlConnection mysqlConnection;

        public ClassOneNeedsMysqlConnection(MysqlConnection connection)
        {
            mysqlConnection = connection;
        }

        public void MakeDbCall()
        {
            mysqlConnection.someDbMethod();
        }
    }

    public class ClassTwoNeedsMysqlConnection
    {
        public string Name { get; private set; }
        private MysqlConnection connection;

        public ClassTwoNeedsMysqlConnection()
        {

        }

        public void MakeDbCall()
        {

        }
    }
}

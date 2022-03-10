using System;

namespace SingletonPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var conn = MysqlConnection_SINGLETON.getInstance();
            ClassOneNeedsMysqlConnection_SINGLETON client1 = new ClassOneNeedsMysqlConnection_SINGLETON(conn);
            ClassTwoNeedsMysqlConnection_SINGLETON client2 = new ClassTwoNeedsMysqlConnection_SINGLETON(conn);

            client1.MakeDbCall();
            client2.MakeDbCall();

        }
    }

    public class ClassOneNeedsMysqlConnection_SINGLETON
    {
        public string Name { get; private set; }
        private MysqlConnection_SINGLETON mysqlConnection;

        public ClassOneNeedsMysqlConnection_SINGLETON(MysqlConnection_SINGLETON connection)
        {
            Console.WriteLine();
            mysqlConnection = connection;
        }

        public void MakeDbCall()
        {
            mysqlConnection.someDbMethod();
        }
    }

    public class ClassTwoNeedsMysqlConnection_SINGLETON
    {
        public string Name { get; private set; }
        private MysqlConnection_SINGLETON mysqlConnection;

        public ClassTwoNeedsMysqlConnection_SINGLETON(MysqlConnection_SINGLETON connection)
        {
            Console.WriteLine();
            mysqlConnection = connection;
        }

        public void MakeDbCall()
        {
            mysqlConnection.someDbMethod();
        }
    }
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

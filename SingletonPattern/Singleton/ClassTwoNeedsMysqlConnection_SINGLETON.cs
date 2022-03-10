using System;

namespace SingletonPattern
{
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
}

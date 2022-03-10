namespace SingletonPattern
{
    //client class
    public class ClassTwoNeedsMysqlConnection
    {
        public string Name { get; private set; }
        private MysqlConnection mysqlConnection;

        public ClassTwoNeedsMysqlConnection(MysqlConnection connection)
        {
            mysqlConnection = connection;
        }

        public void MakeDbCall()
        {
            mysqlConnection.someDbMethod();
        }
    }
}

namespace SingletonPattern
{
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
}

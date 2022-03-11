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
}

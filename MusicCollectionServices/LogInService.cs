using MusicCollectionModel.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MusicCollectionServices
{
    public class DbConnection
    {
        private DbConnection()
        {
        }

        private readonly string _databaseHost = "johncaridi.com";
        private readonly string _databaseName = "johnca14_music_collection";
        private readonly string _userName = "johnca14_music_collection_session";
        private readonly string _password = "Y%ELM8;p?_=6";
        private readonly string _port = "3306";


        private MySqlConnection _connection = null;
        public MySqlConnection Connection
        {
            get { return _connection; }
        }

        private static DbConnection _instance = null;
        public static DbConnection Instance()
        {
            if (_instance == null)
                _instance = new DbConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (string.IsNullOrEmpty(_databaseName))
                    return false;
                string connstring = $"Server=\"{_databaseHost}\"; database=\"{_databaseName}\"; UID=\"{_userName}\"; Port=\"{_port}\"; password=\"{_password}\"";
                _connection = new MySqlConnection(connstring);
                _connection.Open();
            }

            return true;
        }

        public void Close()
        {
            _connection.Close();
            _connection = null;
        }
    }

    public class LogInService : ILogInService
    {
        private class UserInfo : IUserInfo
        {
            public string UserName { get; set; }

            public string LibraryName { get; set; }
        }
        public IUserInfo LogIn(string userName, string password)
        {
            IUserInfo userInfo = null;
            var dbCon = DbConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM music_collection_users";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string userUserName = reader.GetString(0);
                    string userPassword = reader.GetString(1);

                    if (userName.Equals(userUserName) && password.Equals(userPassword))
                    {
                        userInfo = new UserInfo { UserName = userName, LibraryName = "TEST_LIBRARY" };
                    }
                }

                dbCon.Close();
            }

            return userInfo;
        }
    }
}
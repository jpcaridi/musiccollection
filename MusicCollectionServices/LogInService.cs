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
            public int UserId { get; set; }
            public string UserName { get; set; }
            
        }
        public IUserInfo LogIn(string userName, string password)
        {
            var dbCon = DbConnection.Instance();
            if (dbCon.IsConnect())
            {
                int userId = -1;
                string query = $"verify_user";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_name", userName);
                cmd.Parameters.AddWithValue("@user_password", password);
                cmd.Parameters.AddWithValue("@out_user_id", userId);
                cmd.Parameters["@out_user_id"].Direction = System.Data.ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                
                if (!System.DBNull.Value.Equals(cmd.Parameters["@out_user_id"].Value))
                    userId = (int)cmd.Parameters["@out_user_id"].Value;

                if (userId >= 0)
                {
                    return new UserInfo { UserId = userId, UserName = userName };
                }

                dbCon.Close();
            }

            return null;
        }
    }
}
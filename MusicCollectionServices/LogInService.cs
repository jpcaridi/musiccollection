using MusicCollectionModel.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System;

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

        private static class PasswordHasher
        {
            // 24 = 192 bits
            private const int SaltByteSize = 24;
            private const int HashByteSize = 24;
            private const int HasingIterationsCount = 10101;

            public static string Compute(string password)
            {
                var hash = new byte[HashByteSize + SaltByteSize];
                var salt = GenerateSalt();
                var passwordHash = Compute(password, salt);

                Array.Copy(passwordHash, hash, HashByteSize);
                Array.Copy(salt, 0, hash, HashByteSize, SaltByteSize);

                return Convert.ToBase64String(hash);
            }

            public static byte[] Compute(string password, byte[] salt)
            {
                using (var hashGenerator = new Rfc2898DeriveBytes(password, salt))
                {
                    hashGenerator.IterationCount = HasingIterationsCount;
                    return hashGenerator.GetBytes(HashByteSize);
                }
            }

            public static byte[] GenerateSalt(int saltByteSize = SaltByteSize)
            {
                RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
                byte[] salt = new byte[saltByteSize];
                saltGenerator.GetBytes(salt);
                return salt;
            }

            public static bool VerifyPassword(string password, string passwordHashString)
            {
                var passwordHash = new byte[HashByteSize];
                var salt = new byte[SaltByteSize];

                var hashBytes = Convert.FromBase64String(passwordHashString);

                Array.Copy(hashBytes, passwordHash, HashByteSize);
                Array.Copy(hashBytes, SaltByteSize, salt, 0, SaltByteSize);

                var computedHash = Compute(password, salt);
                return AreHashesEqual(computedHash, passwordHash);
            }
            
            private static bool AreHashesEqual(byte[] firstHash, byte[] secondHash)
            {
                int minHashLenght = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
                var xor = firstHash.Length ^ secondHash.Length;
                for (int i = 0; i < minHashLenght; i++)
                    xor |= firstHash[i] ^ secondHash[i];
                return 0 == xor;
            }
        }

        public IUserInfo LogIn(string userName, string password)
        {
            UserInfo userInfo = null;
            var dbCon = DbConnection.Instance();
            if (dbCon.IsConnect())
            {
                string query = "get_user_info";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usr_name", userName);

                var requestReader = cmd.ExecuteReader();

                if (requestReader.Read())
                {
                    int userId = (int)requestReader["user_id"];
                    string userPassword = (string)requestReader["user_password"];

                    if (PasswordHasher.VerifyPassword(password, userPassword))
                    {
                        userInfo = new UserInfo { UserId = userId, UserName = userName };
                    }
                }

                dbCon.Close();
            }

            return userInfo;
        }

        public bool ChangePassword(IUserInfo userInfo, string currentPassword, string newPassword)
        {
            bool passwordChanged = false;
            if (LogIn(userInfo.UserName, currentPassword) != null)
            {
                var dbCon = DbConnection.Instance();
                if (dbCon.IsConnect())
                {
                    string newPasswordHash = PasswordHasher.Compute(newPassword);

                    string query = "change_user_password";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usr_id", userInfo.UserId);
                    cmd.Parameters.AddWithValue("@usr_password", newPasswordHash);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        passwordChanged = true;
                    }
                    dbCon.Close();
                }
            }

            return passwordChanged;
        }
    }
}
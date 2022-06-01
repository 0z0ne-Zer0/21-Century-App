﻿using System.Data.SQLite;
using Pastel;

namespace Code
{
    internal class SQLiteWorker
    {
        //private static string path = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\Resources\Database.sqlite"; //Windows

        private static string path = $@"{Directory.GetCurrentDirectory()}/Resources/Database.sqlite"; //Linux
        private static SQLiteConnection conn = new($"Data Source={path};Version=3;");

        public static void Create()
        {
            SQLiteConnection.CreateFile(path);
            string[] cmd = {"CREATE TABLE \"maincat\" (\"MCID\"  INTEGER UNIQUE, \"Name\"  TEXT, \"URL\" TEXT, PRIMARY KEY(\"MCID\" ASC))",
                "CREATE TABLE \"subcat\" (\"SCID\" INTEGER UNIQUE,\"Name\"  TEXT,\"URL\" TEXT UNIQUE, \"Pages\" INTEGER,\"MCID\"  INTEGER, PRIMARY KEY(\"SCID\" ASC),FOREIGN KEY(\"MCID\") REFERENCES \"maincat\"(\"MCID\"));",
                "CREATE TABLE \"goods\" (\"GID\" INTEGER UNIQUE, \"Name\"  TEXT, \"URL\" TEXT UNIQUE, \"SCID\" INTEGER, PRIMARY KEY(\"GID\" ASC), FOREIGN KEY(\"SCID\") REFERENCES \"subcat\"(\"SCID\"));"};
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
                    Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void Insert<W, X, Y, Z>(List<Tuple<W, X, Y, Z>> ts, string ins1, string ins2, string ins3, string ins4, string cmd)
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
                Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Insert<W, X, Y>(List<Tuple<W, X, Y>> ts, string ins1, string ins2, string ins3, string cmd)
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
                Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Insert<W, X>(List<Tuple<W, X>> ts, string ins1, string ins2, string cmd)
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
                Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Insert<W>(List<Tuple<W>> ts, string ins1, string cmd)
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
                Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Tuple<W, X, Y, Z>> Read<W, X, Y, Z>(string cmd)
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
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }

        public static List<Tuple<W, X, Y>> Read<W, X, Y>(string cmd)
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
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }

        public static List<Tuple<W, X>> Read<W, X>(string cmd)
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
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }

        public static List<Tuple<W>> Read<W>(string cmd)
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
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}\tCaught exception {ex.Message} while performing:\n{cmd}".Pastel("#FF0000"));
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }
    }
}
using Npgsql;
using Pastel;

#pragma warning disable CS8604 // Possible null reference argument.

namespace Code
{
    internal class PGRSQLWorker
    {
        private static NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=def;Password=mypass;Database=mydb;");

        public static void Create()
        {
            string[] cmd = {"CREATE TABLE maincat (MCID INTEGER PRIMARY KEY, Name TEXT, URL TEXT)",
            "CREATE TABLE subcat (SCID INTEGER PRIMARY KEY, Name TEXT, URL TEXT, Pages INTEGER, MCID INTEGER)",
            "CREATE TABLE goods (GID INTEGER PRIMARY KEY, Name TEXT, URL TEXT, SCID INTEGER)"};
            foreach (string arg in cmd)
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand(arg, conn);
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
                    using (var sql = new NpgsqlCommand(cmd, conn))
                    {
                        sql.Parameters.AddWithValue($"@{ins1}", item.Item1);
                        
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
                    using (var sql = new NpgsqlCommand(cmd, conn))
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
                    using (var sql = new NpgsqlCommand(cmd, conn))
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
                    using (var sql = new NpgsqlCommand(cmd, conn))
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
                using (NpgsqlCommand command = new NpgsqlCommand(cmd, conn))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        object tmp1 = reader.GetValue(0), tmp2 = reader.GetValue(1), tmp3 = reader.GetValue(2), tmp4 = reader.GetValue(3);
                        Data.Add(Tuple.Create((W)tmp1, (X)tmp2, (Y)tmp3, (Z)tmp4));
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
                using (NpgsqlCommand command = new NpgsqlCommand(cmd, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
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
                using (NpgsqlCommand command = new NpgsqlCommand(cmd, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
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
                using (NpgsqlCommand command = new NpgsqlCommand(cmd, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
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

#pragma warning restore CS8604 // Possible null reference argument.
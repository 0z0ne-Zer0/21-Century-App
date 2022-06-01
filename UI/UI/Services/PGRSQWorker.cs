using Android.Util;
using Npgsql;
using System;
using System.Collections.Generic;

namespace UI.Services
{
    internal class PGRSQLWorker
    {
        private NpgsqlConnection conn;

        public PGRSQLWorker(string IP = "localhost", string P = "5432", string U = "def", string PS = "mypass", string DBN = "mydb")
        {
            conn = new NpgsqlConnection($"Host={IP};Port={P};User Id={U};Password={PS};Database={DBN};");
        }

        public void Create()
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
                    Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void Insert<W, X, Y, Z>(List<Tuple<W, X, Y, Z>> ts, string ins1, string ins2, string ins3, string ins4, string cmd)
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
                Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
            }
            finally
            {
                conn.Close();
            }
        }

        public void Insert<W, X, Y>(List<Tuple<W, X, Y>> ts, string ins1, string ins2, string ins3, string cmd)
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
                Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
            }
            finally
            {
                conn.Close();
            }
        }

        public void Insert<W, X>(List<Tuple<W, X>> ts, string ins1, string ins2, string cmd)
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
                Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
            }
            finally
            {
                conn.Close();
            }
        }

        public void Insert<W>(List<Tuple<W>> ts, string ins1, string cmd)
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
                Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Tuple<W, X, Y, Z>> Read<W, X, Y, Z>(string cmd)
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
                Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }

        public List<Tuple<W, X, Y>> Read<W, X, Y>(string cmd)
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
                Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }

        public List<Tuple<W, X>> Read<W, X>(string cmd)
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
                Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }

        public List<Tuple<W>> Read<W>(string cmd)
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
                Log.Error("21Century", $"Caught exception {ex.Message} while performing:{cmd}");
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }
    }
}
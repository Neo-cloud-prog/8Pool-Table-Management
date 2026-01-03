using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8pool.Data;
using System.Reflection;

namespace _8pool.Core
{
    public class clsPlayerData
    {
        public static bool GetPlayerInfoByID(int PlayerID, ref string PlayerName, ref int NumberOfGames, ref DateTime JoinDate)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_GetPlayerByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PlayerID", PlayerID);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;

                            PlayerName = (string)reader["PlayerName"];
                            NumberOfGames = (int)reader["NumberOfGames"];
                            JoinDate = (DateTime)reader["JoinDate"];
                        }
                        else
                        {
                            // The record was not found
                            isFound = false;
                        }
                        reader.Close();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists(AppDomain.CurrentDomain.FriendlyName))
                //{
                //    EventLog.CreateEventSource(AppDomain.CurrentDomain.FriendlyName, "Application");
                //}

                //EventLog.WriteEntry(AppDomain.CurrentDomain.FriendlyName, ex.Message, EventLogEntryType.Error);
            }

            return isFound;
        }

        public static bool GetPlayerInfoByName(string PlayerName, ref int PlayerID, ref int NumberOfGames, ref DateTime JoinDate)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_GetPlayerByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PlayerName", PlayerName);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;

                            PlayerID = (int)reader["PlayerID"];
                            NumberOfGames = (int)reader["NumberOfGames"];
                            JoinDate = (DateTime)reader["JoinDate"];
                        }
                        else
                        {
                            // The record was not found
                            isFound = false;
                        }
                        reader.Close();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists(AppDomain.CurrentDomain.FriendlyName))
                //{
                //    EventLog.CreateEventSource(AppDomain.CurrentDomain.FriendlyName, "Application");
                //}

                //EventLog.WriteEntry(AppDomain.CurrentDomain.FriendlyName, ex.Message, EventLogEntryType.Error);
            }

            return isFound;
        }


        public static int AddNewPlayer(string PlayerName)
        {
            int PlayerID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_AddNewPlayer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PlayerName", PlayerName);

                        SqlParameter OutputIdParam = new SqlParameter("@NewPlayerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(OutputIdParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        PlayerID = (int)command.Parameters["@NewPlayerID"].Value;

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists(AppDomain.CurrentDomain.FriendlyName))
                //{
                //    EventLog.CreateEventSource(AppDomain.CurrentDomain.FriendlyName, "Application");
                //}

                //EventLog.WriteEntry(AppDomain.CurrentDomain.FriendlyName, ex.Message, EventLogEntryType.Error);
            }
            return PlayerID;
        }

        public static bool UpdatePlayer(int PlayerID, string PlayerName, int NumberOfGames)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_UpdatePlayer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PlayerID", PlayerID);
                        command.Parameters.AddWithValue("@PlayerName", PlayerName);
                        command.Parameters.AddWithValue("@NumberOfGames", NumberOfGames);

                        SqlParameter OutputIdParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(OutputIdParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        RowsAffected = (int)command.Parameters["@RowsAffected"].Value;

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists(AppDomain.CurrentDomain.FriendlyName))
                //{
                //    EventLog.CreateEventSource(AppDomain.CurrentDomain.FriendlyName, "Application");
                //}

                //EventLog.WriteEntry(AppDomain.CurrentDomain.FriendlyName, ex.Message, EventLogEntryType.Error);
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllPlayers()
        {

            DataTable PlayersTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_GetAllPlayers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            PlayersTable.Load(reader);
                        }
                        reader.Close();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists(AppDomain.CurrentDomain.FriendlyName))
                //{
                //    EventLog.CreateEventSource(AppDomain.CurrentDomain.FriendlyName, "Application");
                //}

                //EventLog.WriteEntry(AppDomain.CurrentDomain.FriendlyName, ex.Message, EventLogEntryType.Error);
            }
            return PlayersTable;
        }

        public static bool DeletePlayer(int PlayerID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_DeletePlayer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PlayerID", PlayerID);

                        SqlParameter OutputIdParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(OutputIdParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        RowsAffected = (int)command.Parameters["@RowsAffected"].Value;

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists(AppDomain.CurrentDomain.FriendlyName))
                //{
                //    EventLog.CreateEventSource(AppDomain.CurrentDomain.FriendlyName, "Application");
                //}

                //EventLog.WriteEntry(AppDomain.CurrentDomain.FriendlyName, ex.Message, EventLogEntryType.Error);
            }

            return (RowsAffected > 0);
        }

        public static bool IsPlayerExist(int PlayerID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_CheckPlayerExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", PlayerID);

                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(ReturnParameter);

                        connection.Open();

                        command.ExecuteNonQuery();

                        isFound = (int)ReturnParameter.Value == 1;

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists(AppDomain.CurrentDomain.FriendlyName))
                //{
                //    EventLog.CreateEventSource(AppDomain.CurrentDomain.FriendlyName, "Application");
                //}

                //EventLog.WriteEntry(AppDomain.CurrentDomain.FriendlyName, ex.Message, EventLogEntryType.Error);
            }

            return isFound;
        }

        public static bool IsPlayerExist(string PlayerName)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_CheckPlayerExistsByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PlayerName", PlayerName);

                        SqlParameter ReturnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(ReturnParameter);

                        connection.Open();

                        command.ExecuteNonQuery();

                        isFound = (int)ReturnParameter.Value == 1;

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists(AppDomain.CurrentDomain.FriendlyName))
                //{
                //    EventLog.CreateEventSource(AppDomain.CurrentDomain.FriendlyName, "Application");
                //}

                //EventLog.WriteEntry(AppDomain.CurrentDomain.FriendlyName, ex.Message, EventLogEntryType.Error);
            }

            return isFound;
        }
    }
}

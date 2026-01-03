using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8pool.Data;

namespace _8pool.Core
{
    public class clsTableData
    {
        public static int AddNewTable(string TableName, float RatePerHour)
        {
            int PlayerID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_AddNewTable", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TableName", TableName);
                        command.Parameters.AddWithValue("@RatePerHour", RatePerHour);

                        SqlParameter OutputIdParam = new SqlParameter("@NewTableID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(OutputIdParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        PlayerID = (int)command.Parameters["@NewTableID"].Value;

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

        public static bool UpdateTable(int TableID, string TableName, int NumberOfPlayers, float RatePerHour)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_UpdateTable", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TableID", TableID);
                        command.Parameters.AddWithValue("@TableName", TableName);
                        command.Parameters.AddWithValue("@NumberOfPlayers", NumberOfPlayers);
                        command.Parameters.AddWithValue("@RatePerHour", RatePerHour);

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

        public static DataTable GetAllTables()
        {

            DataTable Tables = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_GetAllTables", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            Tables.Load(reader);
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
            return Tables;
        }

        public static bool DeleteTable(int TableID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_DeleteTable", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TableID", TableID);

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

        public static bool GetTableInfoByName(string TableName, ref int TableID, ref int NumberOfPlayers, ref float RatePerHour)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_GetTableByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TableName", TableName);

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;

                            TableID = (int)reader["TableID"];
                            NumberOfPlayers = (int)reader["NumberOfPlayers"];
                            RatePerHour =Convert.ToSingle(reader["RatePerHour"]);
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

        public static bool DeleteTable(string TableName)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_DeleteTableByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TableName", TableName);

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

        public static bool IsTableExist(string TableName)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_CheckTableExistsByName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TableName", TableName);

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

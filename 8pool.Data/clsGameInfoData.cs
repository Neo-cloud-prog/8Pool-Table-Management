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
    public class clsGameInfoData
    {
        public static int AddNewGameInfo(int PlayerID, string PlayerName, int TableID, TimeSpan TimeConsumed, int TotalSeconds, decimal TotalFees)
        {
            int GameInfoID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_AddNewGameInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PlayerID", PlayerID);
                        command.Parameters.AddWithValue("@PlayerName", PlayerName);
                        command.Parameters.AddWithValue("@TableID", TableID);

                        command.Parameters.Add("@TimeConsumed", SqlDbType.Time).Value = TimeConsumed;
                        command.Parameters["@TimeConsumed"].Precision = 7;

                        command.Parameters.AddWithValue("@TotalSeconds", TotalSeconds);
                        command.Parameters.AddWithValue("@TotalFees", TotalFees);

                        SqlParameter OutputIdParam = new SqlParameter("@NewGameInfoID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(OutputIdParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        GameInfoID = (int)command.Parameters["@NewGameInfoID"].Value;

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
            return GameInfoID;
        }

        public static DataTable GetAllGameInfo()
        {

            DataTable GameInfoTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_GetAllGameInfo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            GameInfoTable.Load(reader);
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
            return GameInfoTable;
        }
    }
}

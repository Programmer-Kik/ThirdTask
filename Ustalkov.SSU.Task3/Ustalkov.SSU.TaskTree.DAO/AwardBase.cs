using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Ustalkov.SSU.Task3.Entity;

namespace Ustalkov.SSU.Task3.DAO
{
    public class AwardBase : IAwardBase
    {
        private string connectionString = "Data Source=LAPTOP-ST7R1B1J\\SQLEXPRESS;Initial Catalog=Job;Integrated Security=True";

        public string DeleteAward(int awardId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Delete_award_by_id";

                    var parametrId = command.CreateParameter();
                    parametrId.DbType = DbType.Int32;
                    parametrId.ParameterName = "@id";
                    parametrId.Value = awardId;

                    command.Parameters.Add(parametrId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return "Deleted!";
            }
            catch
            {
                throw new Exception("Wrong award id for deleting!");
            }
        }

        public string InsertIntoAward(string awardTitle)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Insert_into_award";

                    var parametrTitle = command.CreateParameter();
                    parametrTitle.DbType = DbType.String;
                    parametrTitle.ParameterName = "@title";
                    parametrTitle.Value = awardTitle;

                    command.Parameters.Add(parametrTitle);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return "Inserted!";
            }
            catch
            {
                throw new Exception("Wrong award title for inserting!");
            }
        }

        public List<Award> SelectAward()
        {
            try
            {
                List<Award> awards = new List<Award>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Select_award";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Award award = new Award((int)reader["award_id"],
                                    (string)reader["award_title"]);
                                awards.Add(award);
                            }
                        }
                    }
                }
                return awards;
            }
            catch
            {
                throw new Exception("Error during reading!");
            }
        }
    }
}

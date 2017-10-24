using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Web.Models;
using System.Data.SqlClient;

namespace Project.Web.DAL
{
    public class GreetingCardSqlDal
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=GreetingCard;User ID=te_student;Password=sqlserver1";
        private const string SQL_GetTemplate = "select * from card_templates where card_templates.id = @tempId;";
        private const string SQL_GetCard = "select * from cards where cards.template_id = @tempId;";
        private const string SQL_InsertCard = "insert into cards values(@tempId, @toEmail, @toName,@message, @fromName,@fromEmail);";

        public bool SaveCard(GreetingCard card)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_InsertCard, conn);
                    cmd.Parameters.AddWithValue("@tempId", card.TemplateId);
                    cmd.Parameters.AddWithValue("@toEmail", card.ToEmail);
                    cmd.Parameters.AddWithValue("@toName", card.ToName);
                    cmd.Parameters.AddWithValue("@message", card.Message);
                    cmd.Parameters.AddWithValue("@fromName", card.FromName);
                    cmd.Parameters.AddWithValue("@fromEmail", card.FromEmail);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }

            catch(SqlException ex)
            {
                throw;
            }
        }
    }
}
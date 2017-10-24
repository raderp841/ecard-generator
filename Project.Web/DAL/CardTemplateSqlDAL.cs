using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Web.Models;
using System.Data.SqlClient;

namespace Project.Web.DAL
{
    public class CardTemplateSqlDAL
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=GreetingCard;User ID=te_student;Password=sqlserver1";
        private const string SQL_GetTemplates = "select * from card_templates;";
        private const string SQL_GetTemplate = "select * from card_templates where card_templates.id = @tempId;";

        public List<CardTemplate> GetAllTemplates()
        {
            List<CardTemplate> output = new List<CardTemplate>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetTemplates, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        CardTemplate ct = new CardTemplate();
                        ct.Id = Convert.ToInt32(reader["id"]);
                        ct.Name = Convert.ToString(reader["name"]);
                        ct.ImageName = Convert.ToString(reader["imageName"]);
                        ct.FontColor = Convert.ToString(reader["fontColor"]);
                        output.Add(ct);
                        
                    }
                }
            }

            catch(SqlException ex)
            {
                throw;
            }

            return output;
        }

        public CardTemplate GetTemplate(int tempId)
        {
            CardTemplate output = new CardTemplate();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetTemplate, conn);

                    cmd.Parameters.AddWithValue("@tempId", tempId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Id = Convert.ToInt32(reader["id"]);
                        output.Name = Convert.ToString(reader["name"]);
                        output.ImageName = Convert.ToString(reader["imageName"]);
                        output.FontColor = Convert.ToString(reader["fontColor"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }

        
    

    }
}
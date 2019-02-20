using KaffeSolution.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KaffeSolution.Web
{
    public class KaffeService
    {

        public List<KaffeModel> GetAll()
        {
            using (var con = GetConnection())
            {
                var cmd = con.CreateCommand();

                cmd.CommandText = "Shops_SelectAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var shops = new List<KaffeModel>();

                    while (reader.Read())
                    {
                        var shop = new KaffeModel
                        {
                            Id = (int)reader["Id"],
                            ShopName = (string)reader["ShopName"],
                            City = (string)reader["City"]
                        };

                        shops.Add(shop);
                    }
                    return shops;
                }
            }
        }


        //helper method to create and open a database connection
        SqlConnection GetConnection()
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            con.Open();
            return con;
        }
    }
}
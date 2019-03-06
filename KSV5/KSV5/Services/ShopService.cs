using KSV5.Models.Domain;
using KSV5.Models.Requests.Shops;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KSV5.Services
{
    public class ShopService
    {
        private static Shop MapShop(IDataReader reader)
        {
            Shop shop = new Shop();
            int startingIndex = 0;
            shop.Id = reader.GetInt32(startingIndex++);
            shop.Name = reader.GetString(startingIndex++);
            shop.AddressLineOne = reader.GetString(startingIndex++);
            shop.AddressLineTwo = reader.GetString(startingIndex++);
            shop.City = reader.GetString(startingIndex++);
            shop.State = reader.GetString(startingIndex++);
            shop.PostalCode = reader.GetString(startingIndex++);
            shop.PhotoURL = reader.GetString(startingIndex++);
            shop.Website = reader.GetString(startingIndex++);
            shop.InstagramHandle = reader.GetString(startingIndex++);
            shop.Description = reader.GetString(startingIndex++);
            shop.TimeOpen = reader.GetString(startingIndex++);
            shop.TimeClose = reader.GetString(startingIndex++);
            shop.Lat = reader.GetDouble(startingIndex++);
            shop.Lng = reader.GetDouble(startingIndex++);
            shop.UserId = reader.GetInt32(startingIndex++);
            shop.DateCreated = reader.GetDateTime(startingIndex++);
            shop.DateModified = reader.GetDateTime(startingIndex++);
            return shop;
        }

        public int Add(ShopAddRequest model)
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "dbo.Shops_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@AddressLineOne", model.AddressLineOne);
                cmd.Parameters.AddWithValue("@AddressLineTwo", model.AddressLineTwo);
                cmd.Parameters.AddWithValue("@City", model.City);
                cmd.Parameters.AddWithValue("@State", model.State);
                cmd.Parameters.AddWithValue("@PostalCode", model.PostalCode);
                cmd.Parameters.AddWithValue("@PhotoURL", model.PhotoURL);
                cmd.Parameters.AddWithValue("@Website", model.Website);
                cmd.Parameters.AddWithValue("@InstagramHandle", model.InstagramHandle);
                cmd.Parameters.AddWithValue("@Description", model.Description);
                cmd.Parameters.AddWithValue("@TimeOpen", model.TimeOpen);
                cmd.Parameters.AddWithValue("@TimeClose", model.TimeClose);
                cmd.Parameters.AddWithValue("@Lat", model.Lat);
                cmd.Parameters.AddWithValue("@Long", model.Lng);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@Id"].Value;
            }
        }

        public void Update(ShopUpdateRequest model)
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "dbo.Shops_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@AddressLineOne", model.AddressLineOne);
                cmd.Parameters.AddWithValue("@AddressLineTwo", model.AddressLineTwo);
                cmd.Parameters.AddWithValue("@City", model.City);
                cmd.Parameters.AddWithValue("@State", model.State);
                cmd.Parameters.AddWithValue("@PostalCode", model.PostalCode);
                cmd.Parameters.AddWithValue("@PhotoURL", model.PhotoURL);
                cmd.Parameters.AddWithValue("@Website", model.Website);
                cmd.Parameters.AddWithValue("@InstagramHandle", model.InstagramHandle);
                cmd.Parameters.AddWithValue("@Description", model.Description);
                cmd.Parameters.AddWithValue("@TimeOpen", model.TimeOpen);
                cmd.Parameters.AddWithValue("@TimeClose", model.TimeClose);
                cmd.Parameters.AddWithValue("@Lat", model.Lat);
                cmd.Parameters.AddWithValue("@Long", model.Lng);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateLatLong(ShopUpdateLatLongRequest model)
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "dbo.Shops_UpdateLatLong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Lat", model.Lat);
                cmd.Parameters.AddWithValue("@Long", model.Lng);
                cmd.ExecuteNonQuery();
            }
        }

        public Shop Get(int id)
        {
            using (var conn = GetConnection())
            {
                Shop shop = null;
                var cmd = conn.CreateCommand();
                cmd.CommandText = "dbo.Shop_SelectByShopId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shop = MapShop(reader);
                    }
                }
                return shop;
            }
        }

        public List<Shop> GetUserShops(int userId)
        {
            using (var conn = GetConnection())
            {
                List<Shop> list = null;
                var cmd = conn.CreateCommand();
                cmd.CommandText = "dbo.Shops_SelectByUserId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Shop shop = MapShop(reader);

                        if (list == null)
                        {
                            list = new List<Shop>();
                        }
                        list.Add(shop);
                    }
                }
                return list;
            }
        }

        public void Delete(int shopId)
        {
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "dbo.Shops_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", shopId);
                cmd.ExecuteNonQuery();
            }
        }

        private SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
using BuWanluWeb._1_Core.Entities;
using BuWanluWeb._2_Service.Service.Interface;
using BuWanluWeb._3_Data.Data;
using BuWanluWeb._3_Data.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BuWanluWeb._2_Service.Service
{
    public class PakaianService : IPakaianService
    {
        private readonly IPakaianRepository pakaianRepository;
        private readonly SqlConnection _db;

        public PakaianService(IPakaianRepository pakaianRepository, IConfiguration configuration)
        {
            this.pakaianRepository = pakaianRepository;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<List<Pakaian>> GetData() 
        {
            try
            {
                string command = pakaianRepository.GetPakaian();
                var result = new List<Pakaian>();
                using (SqlCommand cmd = new SqlCommand(command, _db))
                {
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        result.Add(new Pakaian
                        {
                            PakaianID = Convert.ToInt32(reader["PK_Pakaian_ID"]),
                            Nama = reader["Nama"].ToString(),
                            Harga = Convert.ToDecimal(reader["Harga"]),
                            Image = reader["Image"].ToString()
                        });
                    }
                    await _db.CloseAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pakaian> GetDataOrderByPrice(string urutan)
        {
            try
            {
                string command = pakaianRepository.GetPakaianOrderByPrice(urutan);
                Pakaian result = new Pakaian();
                using (SqlCommand cmd = new SqlCommand(command, _db))
                {
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        result.PakaianID = Convert.ToInt32(reader["PK_Pakaian_ID"]);
                        result.Nama = reader["Nama"].ToString();
                        result.Harga = Convert.ToDecimal(reader["Harga"]);
                        result.Image = reader["Image"].ToString();
                    }
                    await _db.CloseAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

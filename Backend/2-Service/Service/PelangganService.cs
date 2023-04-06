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
    public class PelangganService : IPelangganService
    {
        private readonly IPelangganRepository pelangganRepository;
        private readonly SqlConnection _db;

        public PelangganService(IPelangganRepository pelangganRepository, IConfiguration configuration)
        {
            this.pelangganRepository = pelangganRepository;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<List<Pelanggan>> GetData()
        {
            try
            {
                string command = pelangganRepository.GetPelanggan();
                var result = new List<Pelanggan>();
                using (SqlCommand cmd = new(command, _db))
                {
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        result.Add(new Pelanggan
                        {
                            PelangganID = Convert.ToInt32(reader["PK_Pelanggan_ID"]),
                            Nama = reader["Nama"].ToString(),
                            TanggalBergabung = Convert.ToDateTime(reader["Tanggal_Bergabung"]),
                            Cabang = reader["Cabang"].ToString()
                        }); ;
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

        public async Task<Pelanggan> GetDataTerlama()
        {
            try
            {
                string command = pelangganRepository.GetDataTerlama();
                Pelanggan result = new Pelanggan();
                using (SqlCommand cmd = new(command, _db))
                {
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.PelangganID = Convert.ToInt32(reader["PK_Pelanggan_ID"]);
                            result.Nama = reader["Nama"].ToString();
                            result.TanggalBergabung = Convert.ToDateTime(reader["Tanggal_Bergabung"]);
                            result.Cabang = reader["Cabang"].ToString();
                        }
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
        public async Task<Pelanggan> GetDataTerbaru()
        {
            try
            {
                string command = pelangganRepository.GetDataTerbaru();
                Pelanggan result = new Pelanggan();
                using (SqlCommand cmd = new(command, _db))
                {
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.PelangganID = Convert.ToInt32(reader["PK_Pelanggan_ID"]);
                            result.Nama = reader["Nama"].ToString();
                            result.TanggalBergabung = Convert.ToDateTime(reader["Tanggal_Bergabung"]);
                            result.Cabang = reader["Cabang"].ToString();
                        }
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

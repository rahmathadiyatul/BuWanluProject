using BuWanluWeb._1_Core.Entities;
using BuWanluWeb._2_Service.Service.Interface;
using BuWanluWeb._3_Data.Data;
using BuWanluWeb._3_Data.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BuWanluWeb._2_Service.Service
{
    public class PenjualanService : IPenjualanService
    {
        private readonly IPenjualanRepository penjualanRepository;
        private readonly SqlConnection _db;

        public PenjualanService(IPenjualanRepository penjualanRepository, IConfiguration configuration)
        {
            this.penjualanRepository = penjualanRepository;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<List<Penjualan>> GetData()
        {
            try
            {
                string command = penjualanRepository.GetPenjualan();
                var result = new List<Penjualan>();
                using (SqlCommand cmd = new(command, _db))
                { 
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        result.Add(new Penjualan
                        {
                            PenjualanID = Convert.ToInt32(reader["PK_Penjualan_ID"]),
                            NamaPelanggan = reader["NamaPelanggan"].ToString(),
                            NamaPakaian = reader["NamaPakaian"].ToString(),
                            Qty = Convert.ToInt32(reader["Quantity"]),
                            TotalHarga = Convert.ToDecimal(reader["TotalHarga"]),
                            TanggalTransaksi = Convert.ToDateTime(reader["Tanggal_Transaksi"]),
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

        public async Task<int> GetRevenueByYear(string cabang)
        {
            try
            {
                string command = penjualanRepository.GetRevenueByYear();
                int result = 0;
                using (SqlCommand cmd = new SqlCommand(command, _db))
                {
                    cmd.Parameters.AddWithValue("@Cabang", cabang);
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.Read())
                    {
                        result = Convert.ToInt32(reader["Total_Revenue_Tahunan"]);
                    }
                    await reader.CloseAsync();
                    await _db.CloseAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SalesGrowth>> GetSalesGrowth()
        {
            try
            {
                string command = penjualanRepository.GetSalesGrowth();
                var result = new List<SalesGrowth>();
                using (SqlCommand cmd = new(command, _db))
                {
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        result.Add(new SalesGrowth
                        {
                            NamaPakaian = reader["Nama"].ToString(),
                            QtyThisMonth = Convert.ToInt32(reader["Quantity_Sold_This_Month"]),
                            QtyLastMonth = Convert.ToInt32(reader["Quantity_Sold_Last_Month"]),
                            KenaikanPenjualan = Convert.ToInt32(reader["Increase_In_Sales"])
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

public async Task<List<TopPakaian>> GetTopPenjualanPakaian(string cabang, int bulan)
        {
            try
            {
                string command = penjualanRepository.GetTopPenjualanPakaian();
                var result = new List<TopPakaian>();
                using (SqlCommand cmd = new(command, _db))
                {
                    cmd.Parameters.AddWithValue("@Cabang", cabang);
                    cmd.Parameters.AddWithValue("@Bulan", bulan);
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new TopPakaian
                            {
                                NamaPakaian = reader["Nama_Pakaian"].ToString(),
                                TotalQty = Convert.ToInt32(reader["Total_Quantity"]),
                                Cabang = reader["Cabang"].ToString()
                            });
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

        public async Task<List<TopPelanggan>> GetTopSpenders(string cabang, int bulan)
        {
            try
            {
                string command = penjualanRepository.GetTopSpenders();
                var result = new List<TopPelanggan>();
                using (SqlCommand cmd = new(command, _db))
                {
                    cmd.Parameters.AddWithValue("@Cabang", cabang);
                    cmd.Parameters.AddWithValue("@Bulan", bulan);
                    await _db.OpenAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new TopPelanggan
                            {
                                PelangganID = Convert.ToInt32(reader["PK_Pelanggan_ID"]),
                                NamaPelanggan = reader["Nama"].ToString(),
                                TotalPricePerPax = Convert.ToInt32(reader["TotalBelanja"]),
                                Cabang = reader["Cabang"].ToString()
                            });
                        }
                    }
                await _db.CloseAsync();
                }
            return result;;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

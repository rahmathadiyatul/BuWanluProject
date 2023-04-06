using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BuWanluWeb._1_Core.Entities;
using BuWanluWeb._2_Service.Service.Interface;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System;
using BuWanluWeb._2_Service.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace BuWanluWeb.Controllers
{
    [ApiController]
    public class PenjualanController : Controller
    {
        private readonly IPenjualanService penjualanService;
        private readonly IConfiguration _config;
        public PenjualanController(IPenjualanService penjualanService, IConfiguration config)
        {
            this.penjualanService = penjualanService;
            _config = config;
        }

        [Route("Api/[controller]/GetPenjualan")]
        [HttpGet]
        public async Task<ActionResult> GetPenjualan()
        {
            try
            {
                var result = await penjualanService.GetData();
                return Ok(result);
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }
        [Route("Api/[controller]/GetTopPenjualanPakaian")]
        [HttpGet]
        public async Task<ActionResult> GetTopPenjualanPakaian(string cabang, int bulan)
        {
            try
            {
                var result = await penjualanService.GetTopPenjualanPakaian(cabang, bulan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Api/[controller]/GetTopSpenders")]
        [HttpGet]
        public async Task<ActionResult> GetTopSpenders(string cabang, int bulan)
        {
            try
            {
                var result = await penjualanService.GetTopSpenders(cabang, bulan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Api/[controller]/GetRevenueByYear")]
        [HttpGet]
        public async Task<ActionResult> GetRevenueByYear(string cabang)
        {
            try
            {
                var result = await penjualanService.GetRevenueByYear(cabang);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Api/[controller]/GetSalesGrowth")]
        [HttpGet]
        public async Task<ActionResult> GetSalesGrowth()
        {
            try
            {
                var result = await penjualanService.GetSalesGrowth();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

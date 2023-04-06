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
    public class PelangganController : Controller
    {
        private readonly IPelangganService pelangganService;
        private readonly IConfiguration _config;
        public PelangganController(IPelangganService pelangganService, IConfiguration config)
        {
            this.pelangganService = pelangganService;
            _config = config;
        }
        [Route("Api/[controller]/GetPelanggan")]
        [HttpGet]
        public async Task<ActionResult> GetPelanggan()
        {
            try
            {
                var result = await pelangganService.GetData();
                return Ok(result);
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }
        [Route("Api/[controller]/GetPelangganTerlama")]
        [HttpGet]
        public async Task<ActionResult> GetPelangganTerlama()
        {
            try
            {
                var result = await pelangganService.GetDataTerlama();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Api/[controller]/GetPelangganTerbaru")]
        [HttpGet]
        public async Task<ActionResult> GetPelangganTerbaru()
        {
            try
            {
                var result = await pelangganService.GetDataTerbaru();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

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
    public class PakaianController : Controller
    {
        private readonly IPakaianService pakaianService;
        private readonly IConfiguration _config;
        public PakaianController(IPakaianService pakaianService, IConfiguration config)
        {
            this.pakaianService = pakaianService;
            _config = config;
        }

        [Route("Api/[controller]/GetPakaian")]
        [HttpGet]
        public async Task<ActionResult> GetPakaian()
        {
            try
            {
                var result = await pakaianService.GetData();
                return Ok(result);
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }
        [Route("Api/[controller]/GetPakaianOrderByPrice")]
        [HttpGet]
        public async Task<ActionResult> GetPakaianOrderByPrice(string urutan)
        {
            try
            {
                var result = await pakaianService.GetDataOrderByPrice(urutan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

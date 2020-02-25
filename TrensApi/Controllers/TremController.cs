using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrensApi.Models;
using TrensApi.Services;

namespace TrensApi.Controllers
{
    [Route("api/trens")]
    [ApiController]
    public class TremController : ControllerBase
    {
        // GET: api/Trem
        [HttpGet]
        public IEnumerable<Linha> Get()
        {
            var Linhas = SeleniumService.ObterStatusLinhas();

            //var Linhas = new Linha[]
            //{
            //    new Linha
            //    {
            //        Nome = "Linha 4 - Amarela",
            //        DataAtualizacao = DateTime.Now,
            //        DataOcorrencia = DateTime.Now
            //    },
            //    new Linha
            //    {
            //        Nome = "Linha 5 - Lilás",
            //        DataAtualizacao = DateTime.Now,
            //        DataOcorrencia = DateTime.Now
            //    },
            //};

            return Linhas;
        }
    }
}

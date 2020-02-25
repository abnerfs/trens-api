using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrensApi.Models;

namespace TrensApi.Services
{
    public static class SeleniumService
    {
        private static DateTime GetDataOcorrencia(string DtOcorrenciaStr)
        {
            try
            {
                var r = new Regex(": (.*)");

                var Matches = r.Match(DtOcorrenciaStr);
                var Data = Matches.Groups[1].Value;

                var DataRetorno = DateTime.ParseExact(Data, "dd/MM/yyyy H:mm", CultureInfo.InvariantCulture);
                return DataRetorno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static IEnumerable<Linha> ObterStatusLinhas()
        {
            var Retorno = new List<Linha>();

            try
            {
                var Options = new ChromeOptions();
                Options.AddArguments("headless");

                using(var driver = new ChromeDriver(Options))
                {
                    driver.Navigate().GoToUrl("https://www.diretodostrens.com.br/");

                    var Blocos = driver.FindElementsByCssSelector("body > main > div > div > div");
                    foreach(var Bloco in Blocos)
                    {
                        var Linha = Bloco.FindElement(By.CssSelector("a"))?.Text;
                        if (string.IsNullOrEmpty(Linha.Trim()))
                            continue;

                        var StatusLinha = Bloco.FindElement(By.CssSelector(".card-title"))?.Text;
                        var DataOcorrencia = Bloco.FindElement(By.CssSelector("small"))?.Text;

                        Retorno.Add(new Linha
                        {
                            Nome = Linha,
                            Status = StatusLinha,
                            DataAtualizacao = DateTime.Now,
                            DataOcorrencia = GetDataOcorrencia(DataOcorrencia)
                        }); ;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }            

            return Retorno;

        }
    }
}

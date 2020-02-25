using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrensApi.Models
{
    public class Linha
    {
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nova.Domain.Dtos
{
    public class CriarContaRequest
    {
        public int NumeroConta { get; set; }
        public string Titular { get; set; } = string.Empty;
        public decimal SaldoInicial { get; set; }
    }
}
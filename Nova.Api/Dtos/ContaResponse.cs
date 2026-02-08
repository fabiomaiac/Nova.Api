using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nova.Api.Dtos
{
    public class ContaResponse
    {
        public int NumeroConta { get; set; }
        public string Titular { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
    }
}
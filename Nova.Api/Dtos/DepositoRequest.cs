using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nova.Api.Dtos
{
    public class DepositoRequest
    {
        public int NumeroConta { get; set; }
        public decimal Valor { get; set; }
    }
}
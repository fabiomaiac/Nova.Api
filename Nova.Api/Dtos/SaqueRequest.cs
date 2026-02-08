using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nova.Api.Dtos
{
    public class SaqueRequest
    {
        public int NumeroConta { get; set; }
        public decimal Valor { get; set; }
    }
}
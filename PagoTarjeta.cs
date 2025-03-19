using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcial
{
    internal class PagoTarjeta : Pago
    {
        PagoTarjeta pagoT;
        public override decimal CalcularRecargo()
        {
            return Importe * 0.10M;

        }
    }
}

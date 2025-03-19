using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcial
{
    public class  DelegadoPagoSuperado
    {
        public Pago pago;
        public decimal total;
        public DelegadoPagoSuperado(Pago pPago, decimal pTotal)
        {
            pago = pPago;
            total = pTotal - 10000;

        }
        public Pago Pago => pago;
        public decimal Total => total;
    
    }
}

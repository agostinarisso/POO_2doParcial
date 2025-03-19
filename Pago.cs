using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcial
{
    internal abstract class Pago
    {
        public int Codigo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public bool Estado { get; set; }
        public abstract decimal CalcularRecargo();
        public decimal CancelarPago()
        {
            Estado = true;
            decimal recargo = DateTime.Now > FechaVencimiento ? CalcularRecargo() : 0;
            decimal total = Importe + recargo;
            //Agregar el evento para cuando el pago es > 10000
            return total;
        }


    }
}

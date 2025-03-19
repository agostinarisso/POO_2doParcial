using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcial
{
    public abstract class Pago
    {
        public EventHandler<DelegadoPagoSuperado> PagoSuperado;
        public int Codigo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public bool Estado { get; set; }
        public abstract decimal CalcularRecargo();


        public virtual void OnPagoSuperado(DelegadoPagoSuperado e)
        {
            PagoSuperado?.Invoke(this, e);
        }


    }
}

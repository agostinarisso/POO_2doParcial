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
        //public decimal CancelarPago()
        //{
        //    decimal recargo = CalcularRecargo();
        //    decimal totalAbonado = Importe + recargo;
        //    Estado = true;

        //    // Desencadenar el evento si el monto del pago supera los 10,000
        //    if (totalAbonado > 10000)
        //    {
        //        OnPagoSuperado(new DelegadoPagoSuperado(this, totalAbonado));
        //    }

        //    return totalAbonado;
        //}

        public virtual void OnPagoSuperado(DelegadoPagoSuperado e)
        {
            PagoSuperado?.Invoke(this, e);
        }


    }
}

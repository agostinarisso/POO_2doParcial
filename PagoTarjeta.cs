using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcial
{
    internal class PagoTarjeta : Pago
    {
        public PagoTarjeta(int codigo, DateTime fechaVencimiento, decimal importe, bool estado)
        {
            Codigo = codigo;
            FechaVencimiento = fechaVencimiento;
            Importe = importe;
            Estado = estado;

        }
        public override decimal CalcularRecargo()
        {
            var recargo = Importe * 0.10M;
            return recargo;
        }

        //Constructor PagoTarjeta
        
        ////Método para crear un pago con tarjeta
        //public static PagoTarjeta CrearPagoTarjeta(int codigo, DateTime fechaVencimiento, decimal importe, bool estado)
        //{
        //    return new PagoTarjeta(codigo, fechaVencimiento, importe, estado);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcial
{
    internal class PagoEfectivo : Pago
    {
        //Constructor pago efectio
        public PagoEfectivo(int codigo, DateTime fechaVencimiento, decimal importe, bool estado)
        {
            Codigo = codigo;
            FechaVencimiento = fechaVencimiento;
            Importe = importe;
            Estado = estado;

        }
        public override decimal CalcularRecargo()
        {
            var recargo = Importe * 0.01M;
            return recargo;
        }
        
        ////Método para crear un pago en efectivo
        //public static PagoEfectivo CrearPagoEfectivo(int codigo, DateTime fechaVencimiento, decimal importe, bool estado)
        //{
        //    return new PagoEfectivo(codigo, fechaVencimiento, importe, estado);
        //}
    }
}

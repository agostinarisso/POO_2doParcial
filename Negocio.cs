using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcial
{
    internal class Negocio
    {
        public int Codigo { get; set; }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public List<Proveedor> Proveedores { get; set; } = new List<Proveedor>();
        public List<Pago> Pagos { get; set; }

        public Negocio()
        {
            Proveedores = new List<Proveedor>();
            Pagos = new List<Pago>();
        }
        public void AsignarProveedor(Proveedor proveedor)
        {
            if(!Proveedores.Contains(proveedor))
            {
                Proveedores.Add(proveedor);
                if(!proveedor.Negocios.Contains(this))
                {
                    proveedor.AsignarNegocio(this);
                }
            }
        }
        public void GenerarPago(Pago pago)
        {
            if (pago != null)
            {
                Pagos.Add(pago);
            }
        }
        public bool PuedeEliminar()
        {
            return Pagos.Count == 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2doParcial
{
    class Proveedor
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public List<Negocio> Negocios { get; set; } = new List<Negocio>();
        public List<Pago> Pagos { get; set; }
        public Proveedor()
        {
            Pagos = new List<Pago>();
            Negocios = new List<Negocio>();
        }
        public void AsignarNegocio(Negocio negocio)
        {
            if (!Negocios.Contains(negocio))
            {
                Negocios.Add(negocio);
                if (!negocio.Proveedores.Contains(this))
                {
                    negocio.AsignarProveedor(this);
                }
            }
        }
        public bool PuedeEliminar()
        {
            return Negocios.Count == 0;
        }
    }
}

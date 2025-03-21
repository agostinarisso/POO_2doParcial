using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _2doParcial
{
    public partial class Form1 : Form
    {
        private List<Negocio> listaNegocios = new List<Negocio>();
        private List<Proveedor> listaProveedores = new List<Proveedor>();
        private List<Pago> listaPagos = new List<Pago>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = listaNegocios;
            dataGridView2.DataSource = listaProveedores;
        }

        #region Actualizacion de GRIDS
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Negocio negocioSeleccionado = (Negocio)dataGridView1.SelectedRows[0].DataBoundItem;

                var proveedoresOrdenados = negocioSeleccionado.Proveedores
                  .OrderByDescending(p => p.Pagos.Any(pago => pago.Estado))
                  .ToList();
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = proveedoresOrdenados;
            }
        }
        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                Proveedor proveedorSeleccionado = (Proveedor)dataGridView2.SelectedRows[0].DataBoundItem;

                var negociosOrdenados = proveedorSeleccionado.Negocios
                    .OrderByDescending(p => p.Pagos.Any(pago => pago.Estado))
                    .ToList();
                dataGridView4.DataSource = null;
                dataGridView4.DataSource = negociosOrdenados;

            }


        }
        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarPagos();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        #endregion
        #region METODOS
        public void AgregarNegocio()
        {
            try
            {
                int codigo = Convert.ToInt32(Interaction.InputBox("Ingrese el codigo del negocio"));
                string razonSocial = Interaction.InputBox("Ingrese la razon social (nombre) del negocio");
                int telefono = Convert.ToInt32(Interaction.InputBox("Ingrese el telefono del negocio"));
                string direccion = Interaction.InputBox("Ingrese la direccion del negocio");
                Negocio negocio = new Negocio();
                if (listaNegocios.Any(neg => neg.Codigo == codigo))
                {
                    MessageBox.Show("El negocio ya existe");
                    return;
                }
                else
                {
                    negocio.Codigo = codigo;
                    negocio.RazonSocial = razonSocial;
                    negocio.Telefono = telefono;
                    negocio.Direccion = direccion;
                    listaNegocios.Add(negocio);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = listaNegocios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el negocio");

            }
        }
        public void BorrarNegocio()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    Negocio negocioSeleccionado = (Negocio)dataGridView1.CurrentRow.DataBoundItem;
                    if (!negocioSeleccionado.PuedeEliminar())
                    {
                        MessageBox.Show("No se puede eliminar el negocio porque posee pagos");
                        return;
                    }
                    else
                    {
                        listaNegocios.Remove(negocioSeleccionado);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = listaNegocios;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un negocio");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar el negocio");

            }
        }
        public void ModificarNegocio()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    Negocio negocioSeleccionado = (Negocio)dataGridView1.CurrentRow.DataBoundItem;
                    int codigo = Convert.ToInt32(Interaction.InputBox("Ingrese el nuevo codigo del negocio"));
                    string razonSocial = Interaction.InputBox("Ingrese la nueva razon social (nombre) del negocio");
                    int telefono = Convert.ToInt32(Interaction.InputBox("Ingrese el nuevo telefono del negocio"));
                    string direccion = Interaction.InputBox("Ingrese la nueva direccion del negocio");
                    negocioSeleccionado.Codigo = codigo;
                    negocioSeleccionado.RazonSocial = razonSocial;
                    negocioSeleccionado.Telefono = telefono;
                    negocioSeleccionado.Direccion = direccion;
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = listaNegocios;
                }
                else
                {
                    MessageBox.Show("Seleccione un negocio para modificar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el negocio");
            }
        }
        public void AgregarProveedor()
        {
            try
            {
                int codigo = Convert.ToInt32(Interaction.InputBox("Ingrese el codigo del proveedor"));
                string nombre = Interaction.InputBox("Ingrese el nombre del proveedor");
                int telefono = Convert.ToInt32(Interaction.InputBox("Ingrese el telefono del proveedor"));
                Proveedor proveedor = new Proveedor();
                if (listaProveedores.Any(prov => prov.Codigo == codigo))
                {
                    MessageBox.Show("El proveedor ya existe");
                    return;
                }
                else
                {
                    proveedor.Codigo = codigo;
                    proveedor.Nombre = nombre;
                    proveedor.Telefono = telefono;
                    listaProveedores.Add(proveedor);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = listaProveedores;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el proveedor");
            }
        }
        private void EliminarProveedor()
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    Proveedor proveedorSeleccionado = (Proveedor)dataGridView2.CurrentRow.DataBoundItem;
                    if (!proveedorSeleccionado.PuedeEliminar())
                    {
                        MessageBox.Show("No se puede eliminar el proveedor porque posee negocios");
                        return;
                    }
                    else
                    {
                        listaProveedores.Remove(proveedorSeleccionado);
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = listaProveedores;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un proveedor");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar el proveedor");
            }
        }
        private void ModificarProveedor()
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    Proveedor proveedorSeleccionado = (Proveedor)dataGridView2.CurrentRow.DataBoundItem;
                    int codigo = Convert.ToInt32(Interaction.InputBox("Ingrese el nuevo codigo del proveedor"));
                    string nombre = Interaction.InputBox("Ingrese el nuevo nombre del proveedor");
                    int telefono = Convert.ToInt32(Interaction.InputBox("Ingrese el nuevo telefono del proveedor"));
                    proveedorSeleccionado.Codigo = codigo;
                    proveedorSeleccionado.Nombre = nombre;
                    proveedorSeleccionado.Telefono = telefono;
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = listaProveedores;
                }
                else
                {
                    MessageBox.Show("Seleccione un proveedor para modificar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el proveedor");
            }
        }
        private void AsignarProveedor()
        {
            try
            {
                if (dataGridView1.CurrentRow != null && dataGridView2.CurrentRow != null)
                {
                    Negocio negocioSeleccionado = (Negocio)dataGridView1.CurrentRow.DataBoundItem;
                    Proveedor proveedorSeleccionado = (Proveedor)dataGridView2.CurrentRow.DataBoundItem;
                    negocioSeleccionado.AsignarProveedor(proveedorSeleccionado);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = listaNegocios;
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = listaProveedores;
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = negocioSeleccionado.Proveedores;
                    dataGridView4.DataSource = null;
                    dataGridView4.DataSource = proveedorSeleccionado.Negocios;
                }
                else
                {
                    MessageBox.Show("Seleccione un negocio y un proveedor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar el proveedor");
            }
        }
        private void GenerarPago()
        {
            Negocio negocioSeleccionado = (Negocio)dataGridView1.CurrentRow.DataBoundItem;
            Proveedor proveedorSeleccionado = (Proveedor)dataGridView3.CurrentRow.DataBoundItem;
           
            try
            {
                int codigo = Convert.ToInt32(Interaction.InputBox("Ingrese el codigo del pago", "Codigo"));
                DateTime fecha = Convert.ToDateTime(Interaction.InputBox("Ingrese la fecha devencimiento del pago", "FechaVencimiento"));
                decimal importe = Convert.ToDecimal(Interaction.InputBox("Ingrese el monto del pago", "Importe"));
                string medioDePago = Interaction.InputBox("Ingrese el medio de pago (efectivo / tarjeta)", "TipoPago");
                Pago nuevoPago;
                switch (medioDePago.ToLower())
                {
                    case "efectivo":
                        nuevoPago = new PagoEfectivo(codigo, fecha, importe, false);
                        break;
                    case "tarjeta":
                        nuevoPago = new PagoTarjeta(codigo, fecha, importe, false);
                        break;
                    default:
                        MessageBox.Show("Medio de pago incorrecto");
                        return;
                }
                nuevoPago.PagoSuperado += NuevoPago_PagoSuperado;

                if (importe > 10000)
                {
                    nuevoPago.OnPagoSuperado(new DelegadoPagoSuperado(nuevoPago, importe));
                }

                negocioSeleccionado.GenerarPago(nuevoPago);
                proveedorSeleccionado.Pagos.Add(nuevoPago);
                ActualizarPagos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el pago");
            }
        }
        private void NuevoPago_PagoSuperado(object sender, DelegadoPagoSuperado e)
        {
            MessageBox.Show($"El pago ha sido superado: { e.Total}");
        }
        private void ActualizarPagos()
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView3.SelectedRows.Count >0)
            {
                Negocio negocioSeleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Negocio;
                Proveedor proveedorSeleccionado = dataGridView3.SelectedRows[0].DataBoundItem as Proveedor;

                if (negocioSeleccionado != null & proveedorSeleccionado != null)
                {
                    var pagosDelNegocioyProveedor = negocioSeleccionado.Pagos
                        .Where(p => proveedorSeleccionado.Pagos.Contains(p))
                        .OrderBy(p => p.FechaVencimiento)
                        .ToList();
                    dataGridView5.DataSource = null;
                    dataGridView5.DataSource = pagosDelNegocioyProveedor;
                }
                else
                {
                    dataGridView3.DataSource = null;
                }
                var todosLosPagos = listaProveedores
                    .SelectMany(p => p.Pagos)
                    .OrderBy(p => p.Estado)
                    .ToList();
                dataGridView6.DataSource = null;
                dataGridView6.DataSource = todosLosPagos;

            }
        }
        private void Pagar()
        {
            try
            {
                Pago pagoSeleccionado = (Pago)dataGridView5.CurrentRow.DataBoundItem;
                decimal recargo = 0;
                if (DateTime.Now > pagoSeleccionado.FechaVencimiento)
                {
                    recargo = pagoSeleccionado.CalcularRecargo();

                }
                decimal totalAbonado = pagoSeleccionado.Importe + recargo;
                pagoSeleccionado.Estado = true;
                MessageBox.Show($"El total abonado es {totalAbonado}\nRecargo: {recargo}");
                if (dataGridView4.SelectedRows.Count > 0)
                {
                    Proveedor proveedorSeleccionado = (Proveedor)dataGridView4.SelectedRows[0].DataBoundItem;
                    dataGridView5.DataSource = null;
                    dataGridView5.DataSource = proveedorSeleccionado.Negocios;
                }
                var pagosDiscriminados = listaPagos.Select(p => new
                {
                    p.Codigo,
                    p.FechaVencimiento,
                    p.Importe,
                    Recargo = p.Estado ? p.CalcularRecargo() : 0,
                    TotalAbonado = p.Estado ? p.Importe + p.CalcularRecargo() : 0,
                    Estado = p.Estado ? "Cancelado" : "Pendiente"
                }).ToList();

                dataGridView6.DataSource = null;
                dataGridView6.DataSource = pagosDiscriminados;

            }catch
            {
                MessageBox.Show("Seleccione un pago");
            }
        }
        #endregion
        #region BOTONES
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void agregarNegocio_Click(object sender, EventArgs e)
        {
            AgregarNegocio();

        }

        private void borrarNegocio_Click(object sender, EventArgs e)
        {
            BorrarNegocio();

        }

        private void modificarNegocio_Click(object sender, EventArgs e)
        {
            ModificarNegocio();

        }

        private void agregarProveedor_Click(object sender, EventArgs e)
        {
            AgregarProveedor();

        }

        private void borrarProveedor_Click(object sender, EventArgs e)
        {
            EliminarProveedor();

        }

        private void modificarProveedor_Click(object sender, EventArgs e)
        {
            ModificarProveedor();

        }

        private void asignarProveedor_Click(object sender, EventArgs e)
        {
            AsignarProveedor();
        }

        private void generarPago_Click(object sender, EventArgs e)
        {
            GenerarPago();
        }

        private void pagar_Click(object sender, EventArgs e)
        {
            Pagar();
            ActualizarPagos();
        }
        #endregion




    }
}
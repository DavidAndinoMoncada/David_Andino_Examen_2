using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ticket_Mantenimiento
{
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
        }

        string TipoOperacion;

        Cliente miCliente = null;
        ClienteDB clienteDB = new ClienteDB();
        Ticket ticket = new Ticket();
        TicketDB ticketDB = new TicketDB();

        List<DetalleTicket> listadetalles = new List<DetalleTicket>();

        decimal subtotal = 0;
        decimal isv = 0;
        decimal descuento = 0;
        decimal pagototal = 0;

        private void TicketForm_Load(object sender, System.EventArgs e)
        {
            UsuariotextBox.Text = System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }

        private void BuscarClientebutton_Click(object sender, System.EventArgs e)
        {
            BuscarCliente buscarclienteForm = new BuscarCliente();
            buscarclienteForm.ShowDialog();
            miCliente = new Cliente();
            miCliente = buscarclienteForm.cliente;
            IdentidadtextBox.Text = miCliente.Identidad;
            NombreClientetextBox.Text = miCliente.Nombre;

        }

        private void IdentidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(IdentidadtextBox.Text))
            {
                miCliente = new Cliente();
                miCliente = clienteDB.DevolverClientePorIdentidad(IdentidadtextBox.Text);
                NombreClientetextBox.Text = miCliente.Nombre;
            }
            else
            {
                miCliente = null;
                NombreClientetextBox.Clear();
            }
        }

        private void PreciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(PreciotextBox.Text))
            {
                DetalleTicket detalleTicket = new DetalleTicket();
                detalleTicket.TipoSoporte = TipoSoportecomboBox.Text;
                detalleTicket.DescripcionSolicitud = DescripcionSolicitudtextBox.Text;
                detalleTicket.DescripcionRespuesta = DescripcionRespuestatextBox.Text;
                detalleTicket.Precio = Convert.ToDecimal(PreciotextBox.Text);
                detalleTicket.Total = detalleTicket.Precio;

                subtotal += detalleTicket.Precio;
                isv = subtotal * 0.15M;
                descuento = subtotal * 0.10M;
                pagototal = subtotal + isv - descuento;

                listadetalles.Add(detalleTicket);
                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = listadetalles;

                SubTotaltextBox.Text = subtotal.ToString();
                ISVtextBox.Text = isv.ToString();
                DescuentotextBox.Text = descuento.ToString();
                TotaltextBox.Text = pagototal.ToString();

            }
        }


        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "Guardar")
            {
                ticket.IdentidadCliente = IdentidadtextBox.Text;
                ticket.CodigoUsuario = UsuariotextBox.Text;
                ticket.ISV = Convert.ToDecimal(ISVtextBox.Text);
                ticket.Descuento = Convert.ToDecimal(ISVtextBox.Text);
                ticket.SubTotal = Convert.ToDecimal(SubTotaltextBox.Text);
                ticket.Total = Convert.ToDecimal(TotaltextBox.Text);

                bool inserto = ticketDB.Insertar(ticket);

                if (inserto)
                {
                    MessageBox.Show("Registro Guardado");
                }
                else
                {
                    MessageBox.Show("No se Pudo Guardar el Registro");
                }
            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

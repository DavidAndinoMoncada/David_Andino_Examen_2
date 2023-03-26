using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Ticket_Mantenimiento
{
    public partial class BuscarCliente : Form
    {
        public BuscarCliente()
        {
            InitializeComponent();
        }

        ClienteDB clienteDB = new ClienteDB();

        public Cliente cliente = new Cliente();

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ClientesdataGridView.SelectedRows.Count > 0)
            {
                cliente.Identidad = ClientesdataGridView.CurrentRow.Cells["Identidad"].Value.ToString();
                cliente.Nombre = ClientesdataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                cliente.Telefono = ClientesdataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
                cliente.Correo = ClientesdataGridView.CurrentRow.Cells["Correo"].Value.ToString();
                cliente.Direccion = ClientesdataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
                cliente.FechaNacimiento = Convert.ToDateTime(ClientesdataGridView.CurrentRow.Cells["FechaNacimiento"].Value);
                cliente.EstaActivo = Convert.ToBoolean(ClientesdataGridView.CurrentRow.Cells["EstaActivo"].Value);
                this.Close();
            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            ClientesdataGridView.DataSource = clienteDB.DevolverClientes();
        }

        private void NombretextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ClientesdataGridView.DataSource = clienteDB.DevolverClientesPorNombre(NombretextBox.Text);
        }


    }
}

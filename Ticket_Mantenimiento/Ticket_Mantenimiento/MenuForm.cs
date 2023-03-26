namespace Ticket_Mantenimiento
{
    public partial class MenuForm : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void UsuariotoolStripButton_Click(object sender, System.EventArgs e)
        {
            UsuarioForm clienteForm = new UsuarioForm();
            clienteForm.MdiParent = this;
            clienteForm.Show();
        }

        private void ClientetoolStripButton_Click(object sender, System.EventArgs e)
        {
            ClienteForm clienteForm = new ClienteForm();
            clienteForm.MdiParent = this;
            clienteForm.Show();
        }

        private void TickettoolStripButton_Click(object sender, System.EventArgs e)
        {
            TicketForm clienteForm = new TicketForm();
            clienteForm.MdiParent = this;
            clienteForm.Show();
        }
    }
}

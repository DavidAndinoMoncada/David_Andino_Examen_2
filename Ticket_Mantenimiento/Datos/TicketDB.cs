using Entidades;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Datos
{
    public class TicketDB
    {
        string cadena = "server=localhost; user=root; database=ticket; password=123456";

        public bool Insertar(Ticket tick)
        {
            bool inserto = false;

            try
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("INSERT INTO ticket VALUES ");
                sql.Append("(@IdentidadCliente, @CodigoUsuario, @ISV, @Descuento, @SubTotal, @Total);");


                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();

                    using (MySqlCommand _comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        _comando.CommandType = CommandType.Text;
                        _comando.Parameters.Add("@IdentidadCliente", MySqlDbType.VarChar, 30).Value = tick.IdentidadCliente;
                        _comando.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 50).Value = tick.CodigoUsuario;
                        _comando.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = tick.ISV;
                        _comando.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = tick.Descuento;
                        _comando.Parameters.Add("@SubTotal", MySqlDbType.Decimal).Value = tick.SubTotal;
                        _comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = tick.Total;
                        _comando.ExecuteNonQuery();
                        inserto = true;
                    }
                }
            }
            catch (System.Exception)
            {
            }

            return inserto;
        }
    }
}

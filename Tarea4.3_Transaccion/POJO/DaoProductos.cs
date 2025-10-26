using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea4._3_Transaccion.Backend;

namespace Tarea4._3_Transaccion.POJO
{
    internal class DaoProductos
    {
        public async Task<Producto> BuscarProducto(string code)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost; database=Productos; user=root; pwd=root";
            cn.Open();
            try
            {
                string query = "SELECT * FROM productos WHERE codigo = @code";
                MySqlCommand comando = new MySqlCommand(query, cn);
                comando.Parameters.AddWithValue("@code", code);

                using (var reader = await comando.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Producto
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Descripcion = reader.GetString("descripcion"),
                            Stock = reader.GetInt32("stock"),
                            Precio = reader.GetDecimal("precio"),
                            Estado = reader.GetString("estado"),
                            FechaActualizacion = reader.GetDateTime("fecha_actualizacion")
                        };
                    }
                    return null;
                }
            }
            catch
            {
                throw new Exception("Error al consultar el producto: ");
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

                cn.Dispose();
            }
        }

        public bool DescontinuarProductos(List<Producto> productos)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost; database=Productos; user=root; pwd=root";
            cn.Open();
            MySqlTransaction trans = cn.BeginTransaction();
            try
            {
                foreach (Producto producto in productos)
                {
                    string strSQL = "delete * from productos where codigo = @Codigo";
                    MySqlCommand comando = new MySqlCommand(strSQL, cn);
                    comando.Parameters.AddWithValue("Codigo", producto.Codigo);
                    comando.ExecuteNonQuery();
                    comando.Dispose();
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                trans.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
    }
}

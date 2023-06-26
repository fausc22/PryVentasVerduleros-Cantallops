using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace PryVentasVerduleros_Cantallops
{
    class ClsConexion
    {
        OleDbConnection cnn;
        OleDbCommand cmdVendedor;
        OleDbCommand cmdProducto;
        OleDbCommand cmdVentas;
        OleDbDataReader rdrVendedor;
        OleDbDataReader rdrProducto;
        OleDbDataReader rdrVentas;

        public void CargarDatos(ComboBox cmbProducto, ComboBox cmbVendedor)
        {
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=VERDULEROS.mdb;";
            cmbProducto.SelectedIndex = -1;
            cmbVendedor.SelectedIndex = -1;
            try
            {
                cnn = new OleDbConnection(conexion);
                cmdVendedor = new OleDbCommand();
                cmdVendedor.Connection = cnn;
                cmdVendedor.CommandType = CommandType.TableDirect;
                cmdVendedor.CommandText = "Vendedores";
                cmdProducto = new OleDbCommand();
                cmdProducto.Connection = cnn;
                cmdProducto.CommandType = CommandType.TableDirect;
                cmdProducto.CommandText = "Productos";
                cnn.Open();
                rdrVendedor = cmdVendedor.ExecuteReader();
                rdrProducto = cmdProducto.ExecuteReader();

                cmbVendedor.Items.Clear();
                cmbProducto.Items.Clear();

                DataTable dtVendedor = new DataTable(); 
                DataTable dtProducto = new DataTable(); 

                if (rdrVendedor.HasRows)
                {
                    dtVendedor.Load(rdrVendedor);
                    cmbVendedor.DataSource = dtVendedor;
                    cmbVendedor.ValueMember = "IdVendedor";
                    cmbVendedor.DisplayMember = "NombreVendedor";
                }

                if (rdrProducto.HasRows)
                {
                    dtProducto.Load(rdrProducto);
                    cmbProducto.DataSource = dtProducto;
                    cmbProducto.ValueMember = "IdProducto";
                    cmbProducto.DisplayMember = "NomProducto";
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);

            }
        }

        public void RegistrarVenta(int Vendedor, int Producto, DateTime FechaVenta,  int Cantidad)
        {
            
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=VERDULEROS.mdb;";
            string sql = "INSERT INTO Ventas ([Cod Vendedor], [Cod Producto], Fecha, Kilos) VALUES (@vendedor, @producto, @fechaventa, @cantidad)";
            try 
            {
                cnn = new OleDbConnection(conexion);
                cmdVendedor = new OleDbCommand();
                cmdVendedor.Connection = cnn;
                cmdVendedor.Connection.Open();
                cmdVendedor.CommandType = CommandType.Text;
                cmdVendedor.CommandText = sql;
                string FechaString = FechaVenta.ToShortDateString();
                cmdVendedor.Parameters.AddWithValue("@vendedor", Vendedor);
                cmdVendedor.Parameters.AddWithValue("@producto", Producto);
                cmdVendedor.Parameters.AddWithValue("@fechaventa", FechaString);
                cmdVendedor.Parameters.AddWithValue("@cantidad", Cantidad);

                
                cmdVendedor.ExecuteNonQuery();





            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);

            }



        }
    }
}

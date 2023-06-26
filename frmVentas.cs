using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace PryVentasVerduleros_Cantallops
{
    
    public partial class frmVentas : Form
    {
        
        public frmVentas()
        {
            InitializeComponent();
        }

        private void btnObtener_Click(object sender, EventArgs e)
        {
           
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            ClsConexion objCnn = new ClsConexion();
            objCnn.CargarDatos(cmbProducto, cmbVendedor);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClsConexion objCnn = new ClsConexion();
            objCnn.RegistrarVenta(Convert.ToInt32(cmbVendedor.SelectedValue), Convert.ToInt32(cmbProducto.SelectedValue), dtpFechaVenta.Value, Convert.ToInt32(txtCantidad.Text));
            MessageBox.Show("Venta registrada!", "", MessageBoxButtons.OK);
        }

        private void mrcVenta_Enter(object sender, EventArgs e)
        {

        }
    }
}

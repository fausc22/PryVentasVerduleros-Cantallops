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

        }
    }
}

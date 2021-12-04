using RecetasSLN.Datos.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        private IServicio servicio; 
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            servicio = new Servicio(new Factory()); 
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            List<Receta> lst = servicio.GetAllRecetas().ToList();
            foreach (Receta item in lst)
            {
                dataGridView1.Rows.Add(item.nombre,item.tipo,item.cheff); 
            }
            
        }
    }
}

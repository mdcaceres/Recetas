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
        private Dictionary<string, object> filters;
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            servicio = new Servicio(new Factory());
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            CargarLista();
            CargarCombo();
            //filters.Add("@tipo", DBNull.Value);
            //filters.Add("@nombre", null);
        }

        private void CargarLista()
        {
            List<Receta> lst = servicio.GetAllRecetas().ToList();
            foreach (Receta item in lst)
            {
                dataGridView1.Rows.Add(item.nroReceta,item.nombre, item.tipo.id, item.cheff);
            }

        }

        private void CargarCombo()
        {
            List<TipoReceta> lst = servicio.GetTipos();
            cboTipoReceta.DataSource = lst; 
            cboTipoReceta.DisplayMember = "nombre";
            cboTipoReceta.ValueMember = "id";
        }

        public Dictionary<string, object> ValidarFiltros()
        {
            filters = filters = new Dictionary<string, object>();
            int id = Convert.ToInt32(cboTipoReceta.SelectedValue);
            if (id <= 0)
                filters.Add("tipo", DBNull.Value);
            else filters.Add("tipo", Convert.ToInt32(cboTipoReceta.SelectedValue));
            if (txtNombre.Text.Equals(string.Empty))
                filters.Add("nombre", DBNull.Value);
            else filters.Add("nombre", txtNombre.Text);
            return filters;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            List<Receta> lst = servicio.GetRecetas(ValidarFiltros()).ToList();
            dataGridView1.Rows.Clear();
            foreach (Receta item in lst)
            {
                dataGridView1.Rows.Add(item.nroReceta, item.nombre, item.tipo.id, item.cheff);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                DateTime date = servicio.GetFecha(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                Receta receta = new Receta();
                receta.nroReceta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                receta.fecha_baja = date; 
                if(receta.fecha_baja == DateTime.MinValue)
                {
                    servicio.PutFecha(receta);
                    MessageBox.Show($"se modifico la receta con id {receta.nroReceta}", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.Clear();
                    CargarLista();
                }
                else
                {
                    MessageBox.Show($"la receta ya se ha dado de baja el dia {receta.fecha_baja}");
                }
                
            }
        }
    }
}

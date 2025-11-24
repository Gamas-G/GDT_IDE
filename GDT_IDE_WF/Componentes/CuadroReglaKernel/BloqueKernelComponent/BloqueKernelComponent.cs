using GDTKernel_Model.Componentes.CuadroReglaKernel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.CuadroReglaKernel.BloqueKernelComponent
{
    public partial class BloqueKernelComponent : Form
    {
        public string NombreBloque { get; set; }
        public List<FragmentoJson> Scripts { get; set; }
        public Button ButtonEliminar
        {
            get { return this.btn_EliminarBloque; }
        }
        public event EventHandler SolicitarEliminacion;
        public BloqueKernelComponent()
        {
            InitializeComponent();
            pnl_reglasContenedor.Visible = false;
            this.Height = 75;

            pnl_reglasContenedor.Controls.Add(GenerarPanelRegla());
        }

        public BloqueKernelComponent(string nombre, List<FragmentoJson> scripts)
        {
            InitializeComponent();
            pnl_reglasContenedor.Visible = false;
            this.Height = 75;

            CargarDatos(nombre, scripts);
        }

        private void CargarDatos(string nombre, List<FragmentoJson> scripts)
        {
            txt_nombreBloque.Text = nombre;

            CargarReglas(scripts);
        }

        private void CargarReglas(List<FragmentoJson> scripts)
        {
            foreach (FragmentoJson script in scripts)
            {
                pnl_reglasContenedor.Controls.Add(GenerarPanelRegla(script.Nombre, script.Descripcion, script.Codigo));
            }
        }

        private void CustomEliminarRegla_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta regla de kernel?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            // El botón que fue clickeado
            Button btn = sender as Button;

            if (btn != null)
            {
                // El panel que contiene ese botón
                Panel panelAEliminar = btn.Parent as Panel;

                if (panelAEliminar != null)
                {
                    // Eliminar el panel del FlowLayoutPanel
                    pnl_reglasContenedor.Controls.Remove(panelAEliminar);

                    // Liberar recursos si es necesario
                    panelAEliminar.Dispose();
                }
            }
        }


        private void btn_MinMax_Click(object sender, EventArgs e)
        {
            pnl_reglasContenedor.Visible = !pnl_reglasContenedor.Visible;
            btn_MinMax.Text = pnl_reglasContenedor.Visible ? "▲" : "▼";

            this.Height = pnl_reglasContenedor.Visible ? 286 : 75;
        }

        private Panel GenerarPanelRegla(string nombre = "", string descripcion = "", string codigo = "")
        {
            // Crear nuevo panel
            Panel nuevoPanel = new Panel();
            nuevoPanel.Size = new Size(792, 134);
            //nuevoPanel.Location = new Point(10, 10 + paneles.Count * 110); // Para que no se encimen
            nuevoPanel.BorderStyle = BorderStyle.FixedSingle;

            // Crear Label
            Label lbl_Nombre = new Label();
            lbl_Nombre.Text = "Nombre:";
            lbl_Nombre.Location = new Point(10, 10);
            lbl_Nombre.Size = new Size(49, 13);
            lbl_Nombre.Font = new Font("Consolas", (float)8.25, FontStyle.Bold);
            nuevoPanel.Controls.Add(lbl_Nombre);

            // Crear TextBox
            TextBox txt_Nombre = new TextBox();
            txt_Nombre.Name = "txt_nombre";
            txt_Nombre.Text = nombre;
            txt_Nombre.Location = new Point(87, 5);
            txt_Nombre.Size = new Size(251, 20);
            txt_Nombre.Font = new Font("Consolas", (float)8.25, FontStyle.Bold);
            nuevoPanel.Controls.Add(txt_Nombre);

            // Crear Label
            Label lbl_Descripcion = new Label();
            lbl_Descripcion.Text = "Descripción:";
            lbl_Descripcion.Location = new Point(6, 34);
            lbl_Descripcion.Size = new Size(79, 13);
            lbl_Descripcion.Font = new Font("Consolas", 8, FontStyle.Bold);
            nuevoPanel.Controls.Add(lbl_Descripcion);

            // Crear TextBox
            TextBox txt_Descripcion = new TextBox();
            txt_Descripcion.Name = "txt_descripcion";
            txt_Descripcion.Text = descripcion;
            txt_Descripcion.Location = new Point(87, 31);
            txt_Descripcion.Size = new Size(574, 20);
            txt_Descripcion.Font = new Font("Consolas", (float)8.25, FontStyle.Bold);
            nuevoPanel.Controls.Add(txt_Descripcion);

            // Crear Label
            Label lbl_Codigo = new Label();
            lbl_Codigo.Text = "Codigo:";
            lbl_Codigo.Location = new Point(10, 67);
            lbl_Codigo.Size = new Size(49, 13);
            lbl_Codigo.Font = new Font("Consolas", (float)8.25, FontStyle.Bold);
            nuevoPanel.Controls.Add(lbl_Codigo);

            // Crear TextBox
            TextBox txt_Codigo = new TextBox();
            txt_Codigo.Name = "txt_codigo";
            txt_Codigo.Text = codigo;
            txt_Codigo.Multiline = true;
            txt_Codigo.Location = new Point(87, 64);
            txt_Codigo.Size = new Size(574, 53);
            txt_Codigo.Font = new Font("Consolas", 10, FontStyle.Bold);
            nuevoPanel.Controls.Add(txt_Codigo);

            // Crear Button
            Button btnInterno = new Button();
            btnInterno.Text = "Eliminar Regla";
            btnInterno.Location = new Point(664, 85);
            btnInterno.Size = new Size(120, 32);
            btnInterno.Font = new Font("Consolas", 9, FontStyle.Bold);
            btnInterno.Click += CustomEliminarRegla_Click;
            nuevoPanel.Controls.Add(btnInterno);

            return nuevoPanel;
        }

        private void btn_AgregarRegla_Click(object sender, EventArgs e)
        {
            pnl_reglasContenedor.Controls.Add(GenerarPanelRegla());
        }

        private void btn_EliminarBloque_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este bloque de reglas kernel?", "Confirmar eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            SolicitarEliminacion?.Invoke(this, EventArgs.Empty);
        }

        public GrupoScripts ObtenerDatos()
        {
            // Aquí construyes y devuelves el modelo con los datos del Form2
            return new GrupoScripts
            { 
                Nombre = txt_nombreBloque.Text,
                Modificar = true,
                Scripts = ObtenerListaScripts()
            };
        }

        private List<FragmentoJson> ObtenerListaScripts()
        {
            List<FragmentoJson> _listfragmento = new List<FragmentoJson>();
            foreach (Control panel in pnl_reglasContenedor.Controls)
            {
                if (!(panel is Panel)) continue;

                FragmentoJson _fragmento = null;

                foreach (Control ctrl in panel.Controls)
                {
                    if (!(ctrl is TextBox)) continue;

                    if (_fragmento == null)
                        _fragmento = new FragmentoJson();

                    switch (ctrl.Name)
                    {
                        case "txt_nombre":
                            _fragmento.Nombre = ctrl.Text;
                            break;
                        case "txt_descripcion":
                            _fragmento.Descripcion = ctrl.Text;
                            break;
                        case "txt_codigo":
                            _fragmento.Codigo = ctrl.Text;
                            break;
                        default:
                            break;
                    }

                }
                if (_fragmento != null &&
                    (!string.IsNullOrWhiteSpace(_fragmento.Nombre) ||
                     !string.IsNullOrWhiteSpace(_fragmento.Descripcion) ||
                     !string.IsNullOrWhiteSpace(_fragmento.Codigo)))
                {
                    _listfragmento.Add(_fragmento);
                }
            }

            return _listfragmento;
        }

    }
}

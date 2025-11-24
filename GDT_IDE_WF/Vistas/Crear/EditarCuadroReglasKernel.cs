using GDT_IDE_WF.Componentes.CuadroReglaKernel.BloqueKernelComponent;
using GDTKernel_Model.Componentes.CuadroReglaKernel;
using GDTKernel_Util.Observador;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace GDT_IDE_WF.Vistas.Crear
{
    public partial class EditarCuadroReglasKernel : Form
    {
        private List<BloqueKernelComponent> listaBloqueKernel = new List<BloqueKernelComponent>();
        private GrupoScripts _grupoDefault;
        public EditarCuadroReglasKernel()
        {
            InitializeComponent();

            pnl_contenedorBloquesReglas.WrapContents = false;
            pnl_contenedorBloquesReglas.FlowDirection = FlowDirection.TopDown;
            pnl_contenedorBloquesReglas.AutoScroll = true;

            RenderBloquesReglas();
        }

        void RenderBloquesReglas()
        {
            List<GrupoScripts> data = JsonSerializer.Deserialize<List<GrupoScripts>>(File.ReadAllText("StorageScripts.json"));

            pnl_contenedorBloquesReglas.Controls.Clear();

            if (data.Count <= 0 || data == null) return;

            foreach (GrupoScripts grupo in data)
            {
                if (!grupo.Modificar)
                {
                    _grupoDefault = grupo;
                    continue;
                }

                var bloque = new BloqueKernelComponent(grupo.Nombre, grupo.Scripts);
                bloque.TopLevel = false;
                bloque.SolicitarEliminacion += (s, e) =>
                {
                    pnl_contenedorBloquesReglas.Controls.Remove((BloqueKernelComponent)s);
                    listaBloqueKernel.Remove((BloqueKernelComponent)s);
                    ((BloqueKernelComponent)s).Dispose();
                };
                bloque.Show();
                pnl_contenedorBloquesReglas.Controls.Add(bloque);
                listaBloqueKernel.Add(bloque);
            }
        }

        private void btn_AgregarBloque_Click(object sender, EventArgs e)
        {
            AgregarBloqueReglasKernel();
        }

        private void btn_guardarBloqueReglas_Click(object sender, EventArgs e)
        {
            var listaJson = listaBloqueKernel
                            .Select(f => f.ObtenerDatos())
                            .ToList();

            listaJson.Insert(0, _grupoDefault);

            string json = JsonSerializer.Serialize<List<GrupoScripts>>(listaJson);
            File.WriteAllText("StorageScripts.json", json);

            Observador.NotificarCuadroReglaKernel();

            MessageBox.Show("Bloque de regla kernel agregado correctamente", "Confirmación de Guardado");
        }

        private void AgregarBloqueReglasKernel()
        {
            var bloque = new BloqueKernelComponent();
            bloque.TopLevel = false;
            bloque.SolicitarEliminacion += (s, e) =>
            {
                pnl_contenedorBloquesReglas.Controls.Remove((BloqueKernelComponent)s);
                listaBloqueKernel.Remove((BloqueKernelComponent)s);
                ((BloqueKernelComponent)s).Dispose();
            };
            bloque.Show();
            pnl_contenedorBloquesReglas.Controls.Add(bloque);
            listaBloqueKernel.Add(bloque);
        }
    }
}

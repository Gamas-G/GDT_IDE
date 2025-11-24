using GDTKernel_Bussiness.GDTKernel;
using GDTKernel_Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDT_IDE_WF.Vista.Buscar.ReglaKernelTree
{
    public partial class ReglaTreeForm : Form
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        private readonly IGDTKernel_BLL _gdtKernel_bll;
        private ReglaK _regla { get; set; }
        private List<ReglaKernelArbol> _reglasSeguimiento;
        public ReglaTreeForm(ReglaK regla)
        {
            InitializeComponent();

            treeView1.Visible = false;

            this._gdtKernel_bll = Program.ServiceProvider.GetRequiredService<IGDTKernel_BLL>();
            _regla = regla;
        }

        private Task CrearArbol()
        {
            return Task.Run(() => {
                foreach (var regla in _reglasSeguimiento)
                {
                    var nodo = CrearNodo(regla);
                    treeView1.Nodes.Add(nodo);
                }
            });
        }

        private TreeNode CrearNodo(ReglaKernelArbol regla)
        {
            var nodo = new TreeNode($"{regla.fcValor}");
            if (regla.ReglasSeguimiento != null)
            {
                foreach (var hijo in regla.ReglasSeguimiento)
                {
                    nodo.Nodes.Add(CrearNodo(hijo));
                }
            }
            return nodo;
        }

        private Task CargarArbol()
        {
            return Task.Run(() =>
            {
                _reglasSeguimiento = this._gdtKernel_bll.ConsultarArbolSeguimiento(_regla);
            });
        }

        private async void ReglaTreeForm_Load(object sender, EventArgs e)
        {
            await CargarArbol();
            await CrearArbol();

            //await HighlightOddNodes(treeView1.Nodes);

            picture_wait.Visible = false;
            treeView1.Visible = true;
        }

        // Método para resaltar los nodos impares
        private Task HighlightOddNodes(TreeNodeCollection nodes, int level = 0)
        {
            return Task.Run(() => { 
            for (int i = 0; i < nodes.Count; i++)
            {
                if (i % 2 != 0)
                {
                    nodes[i].BackColor = Color.LightGray; // Establece el color de fondo para los nodos impares
                }

                // Llama recursivamente al método para los nodos hijos
                if (nodes[i].Nodes.Count > 0)
                {
                    HighlightOddNodes(nodes[i].Nodes, level + 1);
                }
            }
            });
        }
    }
}

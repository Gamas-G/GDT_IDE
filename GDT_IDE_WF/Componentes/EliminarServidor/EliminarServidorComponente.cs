using GDTKernel_Model.Eliminar;
using GDTKernel_Model.Sevidores;
using GDTKernel_Util.Servidores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.EliminarServidor
{
    public partial class EliminarServidorComponente : Form
    {
        public Dictionary<string, Dictionary<string, List<string>>> _dataInfoServidor;
        public string pais { private get; set; }

        private string _msjInfo = "Eliminación de laboratorios en IDE Kernel.\n" +
                                "Caso 1: Para eliminar todo el país, canales y laboratorios, selecciona el nodo del país.\n" +
                                "Caso 2: Para eliminar todos los laboratorios de un canal, seleccionar el nodo del canal.\n" +
                                "Caso 3: Para elimina un o varios laboratorios, seleccionar los que deseas eliminar.";
        public EliminarServidorComponente()
        {
            InitializeComponent();

            lbl_info.Text = _msjInfo;
        }

        public void RefreshServidores()
        {
            treeView_DataServidor.Nodes.Clear();
            CargarTree();
        }

        private void CargarTree()
        {
            //Nodo principal (el nombre del país)
            List<Canal> _detallePais = Servidores.ConsultarDetallePais(this.pais);
            int _canItem = 0;
            treeView_DataServidor.BeginUpdate();
            treeView_DataServidor.Nodes.Add(pais);


            for (int i = 0; i < _detallePais.Count; i++)
            {
                treeView_DataServidor.Nodes[_canItem].Nodes.Add(_detallePais[i].Nombre);
                
                for (int j = 0; j < _detallePais[i].Servidores.Count; j++)
                {
                    treeView_DataServidor.Nodes[_canItem].Nodes[i].Nodes.Add(_detallePais[i].Servidores[j].Nombre);
                }
            }
            treeView_DataServidor.EndUpdate();
            
        }

        private void EliminarServidorComponente_Load(object sender, EventArgs e)
        {
            CargarTree();
            treeView_DataServidor.ExpandAll();
        }

        private async void btn_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Seguro que desea eliminar este laboratorio?","Eliminar",MessageBoxButtons.YesNo);

            if (resp == DialogResult.No) return;

            if( await Servidores.EliminarServidor(ObtenerSeleccion()))
            {
                this.Close();
            }
            else
            {
                RefreshServidores();
            }
        }

        private PaisDel ObtenerSeleccion()
        {
            PaisDel _p = new PaisDel();
            CanalDel _c;
            List<DetalleServidor> _listDet;
            List<CanalDel> _listCanlDel = new List<CanalDel>();
            bool noCanal = false;



            foreach (TreeNode nodePais in treeView_DataServidor.Nodes)
            {
                //Validación del país (si el pais esta seleccionado, terminamos ya que eliminaremos todo el país)
                if (nodePais.Checked)
                {
                    _p.Nombre = nodePais.Text;
                    _p.Seleccionado = true;
                    break;
                }

                TreeNodeCollection canales = nodePais.Nodes;

                for (int i = 0; i < canales.Count; i++)
                {
                    _listDet = new List<DetalleServidor>();
                    _c = new CanalDel { Nombre = canales[i].Text };
                    //Sí el canal esta seleccionado, lo colocamos true y continuamos con el otro canal ya que este eliminara todos sus laboratorios
                    if (canales[i].Checked)
                    {
                        _c.Seleccionado = true;
                        _listCanlDel.Add(_c);
                        continue;
                    }

                    //Sí no esta seleccionado el canal, procedemos a buscar los laboratorios seleccionados
                    foreach (TreeNode nodeLaboratorio in canales[i].Nodes)
                    {
                        if (!nodeLaboratorio.Checked)
                        {
                            continue;
                        }

                        _listDet.Add( new DetalleServidor { Nombre = nodeLaboratorio.Text } );
                    }

                    if (_listDet.Count <= 0) continue;

                    _c.Servidores = _listDet;
                    _listCanlDel.Add(_c);
                }
                _p.Nombre = nodePais.Text;
                _p.CanalesDel = _listCanlDel;

            }
            return _p;
        }

        private bool updatingTreeView;
        private void treeView_DataServidor_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (updatingTreeView) return;
            updatingTreeView = true;
            SelectParents(e.Node);
            updatingTreeView = false;
        }

        private void SelectParents(TreeNode node)
        {
            bool nodoshijs = false;

            TreeNodeCollection hijos = node.Nodes;
            //Nueva logica ciclica
            if (hijos == null || hijos.Count <= 0) return;

            foreach (TreeNode item in hijos)
            {
                item.Checked = item.Checked ? false : true;
                nodoshijs = (item.Nodes.Count > 0) ? true : false;
                if(item.Nodes.Count > 0)
                {
                    SelectParents(item);
                }
            }
        }
    }
}

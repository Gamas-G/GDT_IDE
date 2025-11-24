using FastColoredTextBoxNS;
using GDTKernel_Interprete.Semantico;
using System;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.Editor
{
    public enum TipoEnum
    {
        Editor,
        Actualizacion
    }
    public partial class EditorComponent : Form, IEditorComponent
    {
        private string _codigo = string.Empty;
        public TipoEnum tipoUso = TipoEnum.Editor;
        bool ValidarReglas = true;
        bool IsValidoJson = false;
        FastColoredTextBox fctb = new FastColoredTextBox();
        public event Action<string, bool> OnEnviarTexto;

        TextStyle errorStyle = new TextStyle(Brushes.Red, null, FontStyle.Underline);


        // Estilos personalizados para JSON
        TextStyle estiloClave = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        TextStyle estiloValor = new TextStyle(Brushes.DarkOrange, null, FontStyle.Regular);
        TextStyle estiloCadena = new TextStyle(Brushes.Brown, null, FontStyle.Italic);

        public Button BtnSelectReglas 
        { 
            get 
            { 
                return this.btn_guardar; 
            } 
        }

        public EditorComponent()
        {
            InitializeComponent();

            labelResultado.Text = string.Empty;

            timer1.Interval = 500;
            timer1.Tick += ValidarJson;

            fctb.Dock = DockStyle.Fill;
            fctb.Font = new Font("Consolas", 12);
            fctb.BackColor = Color.Black;
            fctb.ForeColor = Color.White;

            pnl_contnederoeditor.Controls.Add(fctb);
            fctb.TextChanged += fctb_TextChanged;

            this.btn_cancelar.Visible = false;

            RenderRegla();
        }

        private void RenderRegla()
        {
            fctb.Text = tipoUso != TipoEnum.Editor
                ? string.Empty 
                : "{\n" +
                    "\"e\":\"\",\n" +
                    "\"i\":0\n" +
                  "}";
        }

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {

            timer1.Stop();
            timer1.Start();


            // Limpia estilos previos excepto errores
            e.ChangedRange.ClearStyle(estiloClave, estiloValor, estiloCadena);

            // Claves (entre comillas seguidas de dos puntos)
            e.ChangedRange.SetStyle(estiloClave, "\"(.*?)\"(?=\\s*:)");

            // Valores (entre comillas después de dos puntos)
            e.ChangedRange.SetStyle(estiloValor, "(?<=:\\s*)\"(.*?)\"");

            // Cadenas sueltas
            e.ChangedRange.SetStyle(estiloCadena, "\".*?\"");

            // Símbolos JSON
            //e.ChangedRange.SetStyle(estiloSimbolo, @"[\{\}\[\]:,]");
        }

        private void ValidarJson(object sender, EventArgs e)
        {
            timer1.Stop(); // detiene el temporizador para evitar múltiples ejecuciones

            if (!ValidarReglas)
            {
                timer1.Stop();
                fctb.Range.ClearStyle(errorStyle); // Limpia estilo de error anterior
                labelResultado.Visible = false;
                return; // Omitimos la validación de estructura y la semantica
            }

            fctb.Range.ClearStyle(errorStyle); // Limpia estilo de error anterior
            labelResultado.Visible = false;

            //Validamos el tipo ya que el editor lo puede usar el modulo d ecreeacion o edición de reglas
            _codigo = tipoUso == TipoEnum.Editor ? $"[{fctb.Text}]" : fctb.Text;

            if (tipoUso == TipoEnum.Editor && _codigo.StartsWith("[[") && _codigo.EndsWith("]]"))
            {
                labelResultado.Text = "Favor de retirar los carcteres '[]', de las reglas kernel";
                labelResultado.Visible = true;
                IsValidoJson = false;
                return;
            }

            if (tipoUso == TipoEnum.Actualizacion && _codigo.StartsWith("[") && _codigo.EndsWith("]"))
            {
                labelResultado.Text = "El modo de actualización no permite array de reglas kernel";
                labelResultado.Visible = true;
                IsValidoJson = false;
                return;
            }

            if (!EsJsonValido(_codigo, out string error, out int lineaError))
            {
                //int linea = BuscarLineaReal(texto, error);
                labelResultado.Text = error;
                ResaltarError(lineaError);
                labelResultado.Visible = true;
                IsValidoJson = false;
                return;
            }

            //INICIA ETAPA DE SEMANTICA
            var doc = JsonDocument.Parse(_codigo);
            var root = doc.RootElement;
            IsValidoJson = true;

            if (tipoUso == TipoEnum.Actualizacion)
            {
                if (!Semantico.ValidarSemantica(root, out string msjerror))
                {
                    labelResultado.Visible = true;
                    labelResultado.Text = msjerror;
                }
                return;
            }

            foreach (var bloque in root.EnumerateArray())
            {
                if (!Semantico.ValidarSemantica(bloque, out string msjerror))
                {
                    labelResultado.Visible = true;
                    labelResultado.Text = msjerror;
                }
            }

        }

        public bool EsJsonValido(string textoJson, out string mensajeError, out int lineaError)
        {
            try
            {
                JsonDocument.Parse(textoJson);
                mensajeError = null;
                lineaError = -1;
                return true;
            }
            catch (JsonException ex)
            {
                mensajeError = ex.Message;
                lineaError = (int)ex.LineNumber; // JsonException da línea 1-based
                //lineaError = (int)ex.LineNumber == 0 ? 0 : (int)ex.LineNumber -1; // JsonException da línea 1-based
                return false;
            }
        }

        private void ResaltarError(int linea)
        {
            fctb.BeginUpdate();
            fctb.Range.ClearStyle(errorStyle); // Limpia estilo de error anterior
            fctb.EndUpdate();


            if (linea >= 0 && linea < fctb.LinesCount)
            {
                int longitud = fctb.Lines[linea].Length;
                /*
                var rangoExacto = new Range(fctb, 0, linea, longitud, linea);
                rangoExacto.SetStyle(errorStyle);
                */

                var rangoLinea = fctb.GetLine(linea); // Obtiene el rango de la línea
                rangoLinea.SetStyle(errorStyle);      // Aplica el estilo
            }
        }
    
        public void SetReglaEditor(string regla)
        {
            if(fctb.Text.Length > 0)
            {
                fctb.AppendText("," + Environment.NewLine + regla);
            }
            else
            {
                fctb.AppendText(regla + Environment.NewLine);
            }
        }

        public void SetValidarRegla(bool valor)
        {
            ValidarReglas = valor;
        }

        public void SetTipo(TipoEnum tipo)
        {
            tipoUso = tipo;
            RenderRegla();
            this.btn_cancelar.Visible = true;
            //this.FormBorderStyle = tipo == TipoEnum.Actualizacion ? FormBorderStyle.Sizable : FormBorderStyle.None;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!IsValidoJson) return;

            if (!ValidarReglas) _codigo = fctb.Text;

            string msj = tipoUso == TipoEnum.Editor ? "¿DESEAS CONTINUAR CON LA CREACIÓN DE LAS REGLAS?" : "¿ESTAS SEGURO EN ACTUALIZAR LA SIGUIENTE REGLA KERNEL?";

            DialogResult result = MessageBox.Show(msj, "GUARDAR", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK) return;

            OnEnviarTexto?.Invoke(_codigo, ValidarReglas);

            if (tipoUso == TipoEnum.Actualizacion) this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

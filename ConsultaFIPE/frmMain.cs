using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebServiceFIPE;
using WebServiceFIPE.Modelo;

namespace ConsultaFIPE
{
    public partial class frmMain : Form
    {
        List<TipoFIPEinfo> tipos = new List<TipoFIPEinfo>();
        List<MarcaFIPEinfo> marcasFIPE = new List<MarcaFIPEinfo>();
        List<CarroFIPEinfo> carrosFIPE = new List<CarroFIPEinfo>();
        List<CarroAnoFIPEinfo> carrosAnoFIPE = new List<CarroAnoFIPEinfo>();

        /// <summary>
        /// Construtor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento Load do formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            //carrega o combobox com os tipos disponivies para consulta
            PreencherComboBoxTipo();
            //desabilita demais combobox, pois não possuem dados, o carregamento se dá em cascata conforme vai sendo selecionado os dados
            cmbFabricante.Enabled = false;
            cmbModelo.Enabled = false;
            cmbAnoModelo.Enabled = false;
        }

        /// <summary>
        /// método que preenche os dados no combobox tipo
        /// </summary>
        private void PreencherComboBoxTipo()
        {
            try
            {
                tipos = new Consulta().ConsultarTiposFIPE();

                //preenche o combo fabricantes
                cmbTipo.DataSource = tipos;
                cmbTipo.DisplayMember = "Descricao";
                cmbTipo.ValueMember = "Tipo";
                cmbTipo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento da seleção do combobox tipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                marcasFIPE = new Consulta().ConsultarMarcasFIPE((string)cmbTipo.SelectedValue);

                //preenche o combo fabricantes
                cmbFabricante.DataSource = marcasFIPE;
                cmbFabricante.DisplayMember = "Fipe_Name";
                cmbFabricante.ValueMember = "Id";
                cmbFabricante.SelectedIndex = -1;

                cmbFabricante.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento da seleção do combobox fabricante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFabricante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                carrosFIPE = new Consulta().ConsultarCarrosFIPE((string)cmbTipo.SelectedValue, (int)cmbFabricante.SelectedValue);

                //preenche o combo carros
                cmbModelo.DataSource = carrosFIPE;
                cmbModelo.DisplayMember = "fipe_name";
                cmbModelo.ValueMember = "id";
                cmbModelo.SelectedIndex = -1;

                cmbModelo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento da seleção do combobox modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                carrosAnoFIPE = new Consulta().ConsultarCarrosAnoFIPE((string)cmbTipo.SelectedValue, (int)cmbFabricante.SelectedValue, (long)cmbModelo.SelectedValue);

                //preenche o combo carros
                cmbAnoModelo.DataSource = carrosAnoFIPE;
                cmbAnoModelo.DisplayMember = "name";
                cmbAnoModelo.ValueMember = "id";
                cmbAnoModelo.SelectedIndex = -1;

                cmbAnoModelo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento click do botão consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsultarFIPE_Click(object sender, EventArgs e)
        {
            ConsultaFIPE((string)cmbTipo.SelectedValue, (int)cmbFabricante.SelectedValue, (long)cmbModelo.SelectedValue, (string)cmbAnoModelo.SelectedValue);
        }

        /// <summary>
        /// Método realiza a consulta
        /// </summary>
        /// <param name="tipo">tipo de veiculo</param>
        /// <param name="idMarca">código da marca</param>
        /// <param name="idModelo">código do modelo</param>
        /// <param name="idAnoModelo">código do ano do modelo</param>
        private void ConsultaFIPE(string tipo, int idMarca, long idModelo, string idAnoModelo)
        {
            try
            {
                FIPEInfo consulta = new Consulta().ConsultarPreco(tipo, idMarca, idModelo, idAnoModelo);

                label24.Text = $"Marca: {consulta.marca}";
                label23.Text = $"Veiculo: {consulta.veiculo}";
                label22.Text = $"Ano modelo: {consulta.ano_modelo}";
                label21.Text = $"Combustivel: {consulta.combustivel}";
                label20.Text = $"Preço: {consulta.preco}";
                label19.Text = $"Referência: {consulta.referencia}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Problemas ao consultar dados no servidor da FIPE: {ex.Message}", "Falha de conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }               
    }
}

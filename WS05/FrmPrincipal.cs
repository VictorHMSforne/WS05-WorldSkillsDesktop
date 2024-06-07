using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace WS05
{
    public partial class FrmPrincipal : Form
    {
        

        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
            Conecta con = new Conecta();
            List<Conecta> pessoa = con.ListaPessoa();     
            dgvPessoa.DataSource = pessoa;

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            
            Conecta con = new Conecta();
            DateTime ni = Convert.ToDateTime(mkDataNasci.Text);
            string Hj = DateTime.Now.ToString("yyyy");
            string Niver = ni.ToString("yyyy");

            int idade = Convert.ToInt32(Hj) - Convert.ToInt32(Niver);
        
            string cpf = txtCPF.Text;
            if (con.RegistroRepetido(cpf)==true)
            {
                MessageBox.Show("Erro", "Pessoa Já Cadastrada!", MessageBoxButtons.OK);
            }
            else
            {
                con.Inserir(txtNome.Text, txtCPF.Text, mkDataNasci.Text, idade.ToString());
                MessageBox.Show("Sucesso!", "Pessoa Cadastrada com Sucesso!", MessageBoxButtons.OK);

                List<Conecta> pessoas = con.ListaPessoa();
                dgvPessoa.DataSource = pessoas;

            }
            

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Conecta con = new Conecta();
            DateTime ni = Convert.ToDateTime(mkDataNasci.Text);
            string Hj = DateTime.Now.ToString("yyyy");
            string Niver = ni.ToString("yyyy");

            int idade = Convert.ToInt32(Hj) - Convert.ToInt32(Niver);

            int id = Convert.ToInt32(txtId.Text);


            string cpf = txtCPF.Text;
            if (con.RegistroRepetido(cpf) == true)
            {
                MessageBox.Show("Erro", "Pessoa Já Cadastrada!", MessageBoxButtons.OK);
            }
            else
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Erro", "Insira algum Id!", MessageBoxButtons.OK);
                }
                else
                {
                    con.Atualizar(id, txtNome.Text, txtCPF.Text, mkDataNasci.Text, idade.ToString());
                    MessageBox.Show("Sucesso!", "Pessoa Alterada com Sucesso!", MessageBoxButtons.OK);

                    List<Conecta> pessoas = con.ListaPessoa();
                    dgvPessoa.DataSource = pessoas;
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Conecta con = new Conecta();
            int id = Convert.ToInt32(txtId.Text);
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Erro", "Insira algum Id!", MessageBoxButtons.OK);
            }
            else
            {
                con.Excluir(id);
                MessageBox.Show("Sucesso!", "Pessoa Excluída com Sucesso!", MessageBoxButtons.OK);

                List<Conecta> pessoas = con.ListaPessoa();
                dgvPessoa.DataSource = pessoas;
            }

        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            Conecta con = new Conecta();
            int id = Convert.ToInt32(txtId.Text);

            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Erro", "Insira algum Id!", MessageBoxButtons.OK);
            }
            else
            {

                con.Localizar(id);
                
                txtNome.Text = con.Nome;
                txtCPF.Text = con.CPF;

                MessageBox.Show("Sucesso!", "Pessoa Localizada com Sucesso!", MessageBoxButtons.OK);

                

            }
        }
    }
}

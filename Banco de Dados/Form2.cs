using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_de_Dados
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=pokeagenda;password=;");
            MySqlCommand cmd = new MySqlCommand("INSERT INTO t_pokemon(nome,peso,altura,tipo,grau_evolucao,cidade) VALUES (@Nome, @Peso, @Altura, @Tipo, @Grau_evolucao,@Cidade)", conn);

            //Inserção no banco de Dados
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Peso", txtPeso.Text);
            cmd.Parameters.AddWithValue("@Altura", txtAltura.Text);
            cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text);
            cmd.Parameters.AddWithValue("@Grau_evolucao", txtGrauEvolucao.Text);
            cmd.Parameters.AddWithValue("@Cidade", txtCidade.Text);

            //abrindo conexão
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            //Validando a Inserção de Dados
            if (rowsAffected > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso!");

            }
            else{
                MessageBox.Show("Falha ao inserir dados.");
            }
        }
    }
}

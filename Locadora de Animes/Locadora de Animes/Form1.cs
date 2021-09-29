using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Locadora_de_Animes
{
    public partial class Form1 : Form   
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MySqlConnectionStringBuilder conexaoBanco() // FAZER A CONEXAO COM O SGBD
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "locadoraanimes";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            conexaoBD.SslMode = 0;
            return conexaoBD;
        }

        private void limparCampos()
        {
            tbNome.Text = "";
            tbCategoria.Text = "";
            tbAno.Text = "";
            tbID.Text = "";
            tbSinopse.Text = "";
            tbEpisodio.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) // ADICIONAR (BOTAO)
        {
            //Console.WriteLine("INSERT INTO animes (nomeAnime,categoriaAnime,sinopseAnime,anoAnime,episodiosAnime)" + "'VALUES('" + tbNome.Text + "','" + tbCategoria.Text + "','" + tbSinopse.Text + "','" + Convert.ToInt16(tbAno.Text) + "','" + Convert.ToInt16(tbEpisodio.Text) + ")");
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "INSERT INTO animes (nomeAnime,categoriaAnime,sinopseAnime,anoAnime,episodiosAnime)" +
                   "VALUES('" + tbNome.Text + "','" + tbCategoria.Text + "','" + tbSinopse.Text + "','" + Convert.ToInt16(tbAno.Text) + "','" + Convert.ToInt16(tbEpisodio.Text) + "')";

                comandoMySql.ExecuteNonQuery();

                realizaConexaoBD.Close();
                MessageBox.Show("Novo anime cadastrado com sucesso!");
                atualizarGrid();
                limparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível conectar com o banco de dados!");
                Console.WriteLine(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) // LIMPAR (BOTAO)
        {
            limparCampos();
        }

        private void Form1_Load(object sender, EventArgs e) // REFRESH
        {
            atualizarGrid();
        }

        private void atualizarGrid() // ATUALIZAR O DATAGRIDVIEW
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM animes WHERE ativoAnime = 1";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgAnimes.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dgAnimes.Rows[0].Clone(); // PARA CLONAR A LINHA DA TABELA DO BANCO DE DADOS
                    row.Cells[0].Value = reader.GetInt32(0);  // ID
                    row.Cells[1].Value = reader.GetString(1); // NOME
                    row.Cells[2].Value = reader.GetString(2); // CATEGORIA
                    row.Cells[3].Value = reader.GetString(3); // SINOPSE
                    row.Cells[4].Value = reader.GetInt32(4); // ANO
                    row.Cells[5].Value = reader.GetInt32(5); // EPISODIOS
                //    row.Cells[6].Value = reader.GetInt32(6); // ATIVO
                    dgAnimes.Rows.Add(row); // ADD NOVA LINHA NA TABELA
                }
                realizaConexaoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão estável com o banco de dados!\nTente novamente mais tarde.");
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) // EDITAR (BOTAO)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); 

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "UPDATE animes SET nomeAnime = '" + tbNome.Text + "', " +
                    "categoriaAnime = '" + tbCategoria.Text + "', " +
                    "sinopseAnime = '" + tbSinopse.Text + "', " +
                    "episodiosAnime = '" + Convert.ToInt16(tbEpisodio.Text) + "'," +
                    "anoAnime = " + Convert.ToInt16(tbAno.Text) +
                    " WHERE idAnime = " + tbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); 
                MessageBox.Show("Atualizado com sucesso"); 
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão estável com o banco de dados!\nTente novamente mais tarde.");
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) // DESATIVAR (BOTAO)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                comandoMySql.CommandText = "UPDATE animes SET ativoAnime = 0 WHERE idAnime = " + tbID.Text + "";

                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();
                MessageBox.Show("Anime inativado com sucesso!");
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão estável com o banco de dados!\nTente novamente mais tarde.");
                Console.WriteLine(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e) // ATIVAR (BOTAO)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                comandoMySql.CommandText = "UPDATE animes SET ativoAnime = 1 WHERE idAnime = " + tbID.Text + "";

                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();
                MessageBox.Show("Anime ativado com sucesso!");
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão estável com o banco de dados!\nTente novamente mais tarde.");
                Console.WriteLine(ex.Message);
            }
        }
        private void dgAnimes_CellContentClick(object sender, DataGridViewCellEventArgs e) // EVENTO CLICK ROW
        {
            if (dgAnimes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgAnimes.CurrentRow.Selected = true;
                //preenche os textbox com as células da linha selecionada
                tbNome.Text = dgAnimes.Rows[e.RowIndex].Cells["colNome"].FormattedValue.ToString();
                tbCategoria.Text = dgAnimes.Rows[e.RowIndex].Cells["colCategoria"].FormattedValue.ToString();
                tbSinopse.Text = dgAnimes.Rows[e.RowIndex].Cells["colSinopse"].FormattedValue.ToString();
                tbAno.Text = dgAnimes.Rows[e.RowIndex].Cells["colAno"].FormattedValue.ToString();
                tbEpisodio.Text = dgAnimes.Rows[e.RowIndex].Cells["colEpisodios"].FormattedValue.ToString();
                tbID.Text = dgAnimes.Rows[e.RowIndex].Cells["colID"].FormattedValue.ToString();
            }
        }
        
        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e) // INATIVOS (STRIP)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM animes WHERE ativoAnime = 0";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgAnimes.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dgAnimes.Rows[0].Clone(); // PARA CLONAR A LINHA DA TABELA DO BANCO DE DADOS
                    row.Cells[0].Value = reader.GetInt32(0);  // ID
                    row.Cells[1].Value = reader.GetString(1); // NOME
                    row.Cells[2].Value = reader.GetString(2); // CATEGORIA
                    row.Cells[3].Value = reader.GetString(3); // SINOPSE
                    row.Cells[4].Value = reader.GetInt32(4); // ANO
                    row.Cells[5].Value = reader.GetInt32(5); // EPISODIOS
                                                             //    row.Cells[6].Value = reader.GetInt32(6); // ATIVO
                    dgAnimes.Rows.Add(row); // ADD NOVA LINHA NA TABELA
                }
                realizaConexaoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão estável com o banco de dados!\nTente novamente mais tarde.");
                Console.WriteLine(ex.Message);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e) // ATIVOS (STRIP)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM animes WHERE ativoAnime = 1";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgAnimes.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dgAnimes.Rows[0].Clone(); // PARA CLONAR A LINHA DA TABELA DO BANCO DE DADOS
                    row.Cells[0].Value = reader.GetInt32(0);  // ID
                    row.Cells[1].Value = reader.GetString(1); // NOME
                    row.Cells[2].Value = reader.GetString(2); // CATEGORIA
                    row.Cells[3].Value = reader.GetString(3); // SINOPSE
                    row.Cells[4].Value = reader.GetInt32(4); // ANO
                    row.Cells[5].Value = reader.GetInt32(5); // EPISODIOS
                                                             //    row.Cells[6].Value = reader.GetInt32(6); // ATIVO
                    dgAnimes.Rows.Add(row); // ADD NOVA LINHA NA TABELA
                }
                realizaConexaoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão estável com o banco de dados!\nTente novamente mais tarde.");
                Console.WriteLine(ex.Message);
            }
            
        }

        private void button6_Click(object sender, EventArgs e) // DELETAR
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); 
                comandoMySql.CommandText = "DELETE FROM animes WHERE idAnime = " + tbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();
                MessageBox.Show("Anime deletado com sucesso!");
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão estável com o banco de dados!\nTente novamente mais tarde.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

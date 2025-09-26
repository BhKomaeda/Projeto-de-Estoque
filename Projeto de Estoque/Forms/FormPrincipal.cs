using System;
using System.Windows.Forms;
using ProjetoEstoque.Services;
using ProjetoEstoque.Models;

namespace ProjetoEstoque.Forms
{
    public partial class FormPrincipal : Form
    {
        private readonly ProdutoService service = new ProdutoService();

        public FormPrincipal()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            var lista = service.Listar();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Validações simples
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o nome.");
                return;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco))
            {
                MessageBox.Show("Preço inválido.");
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int qtd))
            {
                MessageBox.Show("Quantidade inválida.");
                return;
            }

            var produto = new Produto
            {
                Nome = txtNome.Text.Trim(),
                Preco = preco,
                Quantidade = qtd
            };

            service.Adicionar(produto);
            CarregarProdutos();

            txtNome.Clear();
            txtPreco.Clear();
            txtQuantidade.Clear();
        }

        private void btnIncrementar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            var selected = dataGridView1.SelectedRows[0].DataBoundItem as Produto;
            if (selected == null) return;

            service.Incrementar(selected.Id, 1);
            CarregarProdutos();
        }

        private void btnDecrementar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            var selected = dataGridView1.SelectedRows[0].DataBoundItem as Produto;
            if (selected == null) return;

            service.Decrementar(selected.Id, 1);
            CarregarProdutos();
        }
    }
}

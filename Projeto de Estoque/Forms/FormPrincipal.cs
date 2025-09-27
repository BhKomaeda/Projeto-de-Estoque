using ProjetoEstoque.Models;
using ProjetoEstoque.Services;

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
            try
            {
                var lista = service.Listar();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
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

            try
            {
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
                MessageBox.Show("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + ex.Message);
            }
        }

        private void btnIncrementar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            try
            {
                var selected = dataGridView1.SelectedRows[0].DataBoundItem as Produto;
                if (selected != null)
                {
                    service.Incrementar(selected.Id, 1);
                    CarregarProdutos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao incrementar: " + ex.Message);
            }
        }

        private void btnDecrementar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            try
            {
                var selected = dataGridView1.SelectedRows[0].DataBoundItem as Produto;
                if (selected != null)
                {
                    service.Decrementar(selected.Id, 1);
                    CarregarProdutos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao decrementar: " + ex.Message);
            }
        }
    }
}
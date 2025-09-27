using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace ProjetoEstoque.Forms
{
    partial class FormPrincipal
    {
        private IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtQuantidade;
        private Button btnCadastrar;
        private Button btnIncrementar;
        private Button btnDecrementar;
        private Label lblNome;
        private Label lblPreco;
        private Label lblQuantidade;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.dataGridView1 = new DataGridView();
            this.txtNome = new TextBox();
            this.txtPreco = new TextBox();
            this.txtQuantidade = new TextBox();
            this.btnCadastrar = new Button();
            this.btnIncrementar = new Button();
            this.btnDecrementar = new Button();
            this.lblNome = new Label();
            this.lblPreco = new Label();
            this.lblQuantidade = new Label();

            ((ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.dataGridView1.Location = new Point(12, 150);
            this.dataGridView1.Size = new Size(560, 250);
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.lblNome.Text = "Nome:";
            this.lblNome.Location = new Point(12, 20);
            this.lblNome.AutoSize = true;

            this.txtNome.Location = new Point(70, 17);
            this.txtNome.Size = new Size(150, 20);

            this.lblPreco.Text = "Preço:";
            this.lblPreco.Location = new Point(240, 20);
            this.lblPreco.AutoSize = true;

            this.txtPreco.Location = new Point(290, 17);
            this.txtPreco.Size = new Size(100, 20);

            this.lblQuantidade.Text = "Qtd:";
            this.lblQuantidade.Location = new Point(410, 20);
            this.lblQuantidade.AutoSize = true;

            this.txtQuantidade.Location = new Point(450, 17);
            this.txtQuantidade.Size = new Size(50, 20);

            this.btnCadastrar.Text = "Cadastrar Produto";
            this.btnCadastrar.Location = new Point(12, 60);
            this.btnCadastrar.Size = new Size(150, 30);
            this.btnCadastrar.Click += new EventHandler(this.btnCadastrar_Click);

            this.btnIncrementar.Text = "Incrementar";
            this.btnIncrementar.Location = new Point(180, 60);
            this.btnIncrementar.Size = new Size(120, 30);
            this.btnIncrementar.Click += new EventHandler(this.btnIncrementar_Click);

            this.btnDecrementar.Text = "Decrementar";
            this.btnDecrementar.Location = new Point(320, 60);
            this.btnDecrementar.Size = new Size(120, 30);
            this.btnDecrementar.Click += new EventHandler(this.btnDecrementar_Click);

            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(584, 421);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnIncrementar);
            this.Controls.Add(this.btnDecrementar);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.lblQuantidade);
            this.Name = "FormPrincipal";
            this.Text = "Controle de Estoque";

            ((ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
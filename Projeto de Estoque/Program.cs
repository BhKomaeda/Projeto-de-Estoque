using ProjetoEstoque.Forms;


namespace ControleEstoque
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }
}

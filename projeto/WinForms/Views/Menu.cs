using Controllers;

namespace Views {


    public class Menu {

        public static void MenuForm() {
            Form menuForm = new Form();
            menuForm.Text = "Menu";
            menuForm.Width = 300;
            menuForm.Height = 300;
            menuForm.StartPosition = FormStartPosition.CenterScreen;
            menuForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            menuForm.MaximizeBox = false;
            menuForm.MinimizeBox = false;
            menuForm.ShowIcon = false;
            menuForm.ShowInTaskbar = false;
            menuForm.TopMost = true;
            menuForm.FormClosed += (sender, e) => { menuForm.Dispose(); };

            Button cadastrarProdutoButton = new Button();
            cadastrarProdutoButton.Text = "Produto";
            cadastrarProdutoButton.Top = 10;
            cadastrarProdutoButton.Left = 10;
            cadastrarProdutoButton.Width = 250;
            cadastrarProdutoButton.Click += (sender, e) =>
            {
                Views.Produto.listarProdutos();
                menuForm.Hide(); 
                menuForm.Close(); // fecha o formulário atual
                
            };

            Button cadastrarAlmoxButton = new Button();
            cadastrarAlmoxButton.Text = "Almoxarifado";
            cadastrarAlmoxButton.Top = 45;
            cadastrarAlmoxButton.Left = 10;
            cadastrarAlmoxButton.Width = 250;
            cadastrarAlmoxButton.Click += (sender, e) =>
            {
                Views.Almoxarifado.listarAlmoxarifado();
                menuForm.Hide(); 
                menuForm.Close(); // fecha o formulário atual
                
            };


            Button cadastrarSaldoButton = new Button();
            cadastrarSaldoButton.Text = "Saldo";
            cadastrarSaldoButton.Top = 80;
            cadastrarSaldoButton.Left = 10;
            cadastrarSaldoButton.Width = 250;
            cadastrarSaldoButton.Click += (sender, e) =>
            {
                Views.Saldo.listarSaldo();
                menuForm.Hide(); 
                menuForm.Close(); // fecha o formulário atual
                
            };


            Button sairButton = new Button();
            sairButton.Text = "Sair";
            sairButton.Top = 115;
            sairButton.Left = 10;
            sairButton.Width = 250;
            sairButton.Click += (sender, e) => { menuForm.Close(); };
            
            menuForm.Controls.Add(sairButton);
            menuForm.Controls.Add(cadastrarAlmoxButton);
            menuForm.Controls.Add(cadastrarSaldoButton);
            menuForm.Controls.Add(cadastrarProdutoButton);
            menuForm.ShowDialog();
            
        }
    }

}
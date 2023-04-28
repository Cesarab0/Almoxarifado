using Controllers;
using Repository;

namespace Views {


    public class Produto {

        public static void listarProdutos() {

            using var context = new Context();

            Form form = new Form();
            form.Text = "Produtos";
            form.Width = 500;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon = false;
            form.ShowInTaskbar = false;
            form.TopMost = true;
            form.FormClosed += (sender, e) => { form.Dispose(); };
            
            ListView lista = new ListView();
            lista.FullRowSelect = true;
            lista.Location = new System.Drawing.Point(10, 10);
            lista.Size = new System.Drawing.Size(480, 350);
            lista.View = View.Details;
           

            lista.Columns.Add("Id");
            lista.Columns.Add("Nome");
            lista.Columns.Add("Preco");

            var produtos = context.produtos.ToList();


            foreach (var produto in produtos)
            {
                lista.Items.Add(new ListViewItem(new[] {produto.Id.ToString(), produto.nome.ToString(), produto.preco.ToString()}));
            }
         

            
            Button cadastrarProdutoButton = new Button();
            cadastrarProdutoButton.Text = "Adicionar";
            cadastrarProdutoButton.Top = 360;
            cadastrarProdutoButton.Left = 10;
            cadastrarProdutoButton.Width = 60;
            cadastrarProdutoButton.Click += (sender, e) => { Views.Produto.addProduto();};

            Button alterarProdutoButton = new Button();
            alterarProdutoButton.Text = "Alterar";
            alterarProdutoButton.Top = 360;
            alterarProdutoButton.Left = 80;
            alterarProdutoButton.Width = 60;
            alterarProdutoButton.Click += (sender, e) => {
                ListViewItem.ListViewSubItem subItem = lista.SelectedItems[0].SubItems[0];
                string textoSubItem = subItem.Text;
                Views.Produto.alterarProduto(int.Parse(subItem.Text));};

            Button excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Top = 360;
            excluirButton.Left = 150;
            excluirButton.Width = 60;
            excluirButton.Click += (sender, e) => {ListViewItem.ListViewSubItem subItem = lista.SelectedItems[0].SubItems[0];
                string textoSubItem = subItem.Text;
                Views.Produto.excluirProduto(int.Parse(subItem.Text));};

            Button SairProdutoButton = new Button();
            SairProdutoButton.Text = "Sair";
            SairProdutoButton.Top = 360;
            SairProdutoButton.Left = 220;
            SairProdutoButton.Width = 60;
            SairProdutoButton.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(cadastrarProdutoButton);
            form.Controls.Add(alterarProdutoButton);
            form.Controls.Add(excluirButton);
            form.Controls.Add(SairProdutoButton);
            form.Controls.Add(lista);
            form.Controls.Add(lista);
            form.ShowDialog();




        }





        public static void addProduto (){
            

            Form form = new Form();
            form.Text = "Produtos";
            form.Width = 500;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon = false;
            form.ShowInTaskbar = false;
            form.TopMost = true;
            form.FormClosed += (sender, e) => { form.Dispose(); };

            Label label_1 = new Label();
            label_1.Text = "Cadastrar produto";
            label_1.Top = 10;
            label_1.Left = 200;
            label_1.Width = 300;

            Label nameLabel = new Label();
            nameLabel.Text = "Nome:";
            nameLabel.Location = new Point(100, 30);
            nameLabel.AutoSize = true;
            form.Controls.Add(nameLabel);


            TextBox texto = new TextBox();
            texto.Top = 55;
            texto.Left = 100;
            texto.Width = 300;
            
            Label precoLabel = new Label();
            precoLabel.Text = "Preco:";
            precoLabel.Location = new Point(100, 90);
            precoLabel.AutoSize = true;
            form.Controls.Add(precoLabel);

            TextBox texto_2 = new TextBox();
            texto_2.Top = 120;
            texto_2.Left = 100;
            texto_2.Width = 300;

            Button CadastraProdutoButton = new Button();
            CadastraProdutoButton.Text = "Cadastrar";
            CadastraProdutoButton.Top = 360;
            CadastraProdutoButton.Left = 300;
            CadastraProdutoButton.Width = 60;
            CadastraProdutoButton.Click += (sender, e) => { 
                Controllers.Produto.criarProduto(new Models.Produto(texto.Text,float.Parse(texto_2.Text))); 
                form.Close();
                Views.Produto.listarProdutos();
                };


            Button SairProdutoButton = new Button();
            SairProdutoButton.Text = "Sair";
            SairProdutoButton.Top = 360;
            SairProdutoButton.Left = 220;
            SairProdutoButton.Width = 60;
            SairProdutoButton.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(texto_2);
            form.Controls.Add(label_1);
            form.Controls.Add(texto);
            form.Controls.Add(SairProdutoButton);
            form.Controls.Add(CadastraProdutoButton);
            form.ShowDialog();
      
        }

        public static void alterarProduto (int id){
          
            Form form = new Form();
            form.Text = "Produtos";
            form.Width = 500;
            form.Height = 500;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon = false;
            form.ShowInTaskbar = false;
            form.TopMost = true;
            form.FormClosed += (sender, e) => { form.Dispose(); };




            Label label_1 = new Label();
            label_1.Text = "Alterar Produto";
            label_1.Top = 10;
            label_1.Left = 200;
            label_1.Width = 300;

           

            Label nameLabel = new Label();
            nameLabel.Text = "Nome:";
            nameLabel.Location = new Point(100, 90);
            nameLabel.AutoSize = true;
            form.Controls.Add(nameLabel);


            TextBox texto = new TextBox();
            texto.Top = 120;
            texto.Left = 100;
            texto.Width = 300;
            
            Label precoLabel = new Label();
            precoLabel.Text = "Preco:";
            precoLabel.Location = new Point(100, 160);
            precoLabel.AutoSize = true;
            form.Controls.Add(precoLabel);

            TextBox texto_2 = new TextBox();
            texto_2.Top = 190;
            texto_2.Left = 100;
            texto_2.Width = 300;

            Button CadastraProdutoButton = new Button();
            CadastraProdutoButton.Text = "Altera";
            CadastraProdutoButton.Top = 360;
            CadastraProdutoButton.Left = 300;
            CadastraProdutoButton.Width = 60;
            CadastraProdutoButton.Click += (sender, e) => { 
                Controllers.Produto.alterarProdutos(id,texto.Text,float.Parse(texto_2.Text)); 
                form.Hide();
                form.Close();
                Views.Produto.listarProdutos();
                };


            Button SairProdutoButton = new Button();
            SairProdutoButton.Text = "Sair";
            SairProdutoButton.Top = 360;
            SairProdutoButton.Left = 220;
            SairProdutoButton.Width = 60;
            SairProdutoButton.Click += (sender, e) => { form.Close(); };

    
            form.Controls.Add(texto_2);
            form.Controls.Add(label_1);
            form.Controls.Add(texto);
            form.Controls.Add(SairProdutoButton);
            form.Controls.Add(CadastraProdutoButton);
            form.ShowDialog();
      
        }



         public static void excluirProduto(int id)
                    {
                        
                                DialogResult result = MessageBox.Show($"Você deseja excluir o produto {id}?", "Confirmação", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                using var context = new Context();
                                var produto = context.produtos.Find(id);
                                if (produto != null)
                                {
                                    context.produtos.Remove(produto);
                                    context.SaveChanges();
                                    Views.Produto.listarProdutos();
                                }
                            }
                        else
                        {
                            MessageBox.Show("Nenhum item selecionado.", "Erro");
                        }
        }


       



    }

}
using Controllers;
using Models;
using Repository;

namespace Views {


    public class Saldo {
    
        public static void listarSaldo() {
        using var context = new Context();

            Form form = new Form();
            form.Text = "Saldo";
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
            lista.Columns.Add("Produto");
            lista.Columns.Add("Almoxaridado");
            lista.Columns.Add("Quantidade");

            var saldos = (
                from saldo in context.saldos
                    join p in context.produtos on saldo.produto_id equals p.Id
                    join a in context.almoxarifados on saldo.almoxarifado_id equals a.Id 
                    select new {
                        Id = saldo.Id,
                        Quantidade = saldo.quantidade,
                        Produto = p,
                        Almoxarifado = a
                    });

           
            foreach (var saldo in saldos)
            {
                lista.Items.Add(new ListViewItem(new[] {saldo.Id.ToString(),saldo.Produto.nome,saldo.Almoxarifado.nome, saldo.Quantidade.ToString() }));
            }

            
            Button cadastrarSaldoButton = new Button();
            cadastrarSaldoButton.Text = "Adicionar";
            cadastrarSaldoButton.Top = 360;
            cadastrarSaldoButton.Left = 10;
            cadastrarSaldoButton.Width = 60;
            cadastrarSaldoButton.Click += (sender, e) => { Views.Saldo.addSaldo();};

            Button alterarSaldoButton = new Button();
            alterarSaldoButton.Text = "Alterar";
            alterarSaldoButton.Top = 360;
            alterarSaldoButton.Left = 80;
            alterarSaldoButton.Width = 60;
            alterarSaldoButton.Click += (sender, e) => {
                ListViewItem.ListViewSubItem subItem = lista.SelectedItems[0].SubItems[0];
                string textoSubItem = subItem.Text;
                Views.Saldo.alterarSaldo(int.Parse(subItem.Text));};

            Button excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Top = 360;
            excluirButton.Left = 150;
            excluirButton.Width = 60;
            excluirButton.Click += (sender, e) => { Views.Saldo.excluirSaldo(int.Parse(lista.SelectedItems[0].SubItems[0].Text));};

            Button SairSaldoButton = new Button();
            SairSaldoButton.Text = "Sair";
            SairSaldoButton.Top = 360;
            SairSaldoButton.Left = 220;
            SairSaldoButton.Width = 60;
            SairSaldoButton.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(cadastrarSaldoButton);
            form.Controls.Add(alterarSaldoButton);
            form.Controls.Add(excluirButton);
            form.Controls.Add(SairSaldoButton);
            form.Controls.Add(lista);
            form.Controls.Add(lista);
            form.ShowDialog();




        }





         public static void addSaldo (){
            

            Form form = new Form();
            form.Text = "Saldos";
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
            label_1.Text = "Cadastrar Saldo";
            label_1.Top = 10;
            label_1.Left = 200;
            label_1.Width = 300;

            Label nameLabel = new Label();
            nameLabel.Text = "Produto id:";
            nameLabel.Location = new Point(100, 30);
            nameLabel.AutoSize = true;
            form.Controls.Add(nameLabel);


            TextBox texto = new TextBox();
            texto.Top = 60;
            texto.Left = 100;
            texto.Width = 300;

            Label nameLabel_2 = new Label();
            nameLabel_2.Text = "Almo id:";
            nameLabel_2.Location = new Point(100, 100);
            nameLabel_2.AutoSize = true;
            form.Controls.Add(nameLabel_2);


            TextBox texto_2 = new TextBox();
            texto_2.Top = 125;
            texto_2.Left = 100;
            texto_2.Width = 300;

            Label nameLabel_3 = new Label();
            nameLabel_3.Text = "Quantidade:";
            nameLabel_3.Location = new Point(100, 170);
            nameLabel_3.AutoSize = true;
            form.Controls.Add(nameLabel_3);


            TextBox texto_3 = new TextBox();
            texto_3.Top = 200;
            texto_3.Left = 100;
            texto_3.Width = 300;
     
     

        
            Button CadastraAlmoxarifadoButton = new Button();
            CadastraAlmoxarifadoButton.Text = "Cadastrar";
            CadastraAlmoxarifadoButton.Top = 360;
            CadastraAlmoxarifadoButton.Left = 300;
            CadastraAlmoxarifadoButton.Width = 60;
            CadastraAlmoxarifadoButton.Click += (sender, e) => { 
                Controllers.Saldo.criarSaldo(int.Parse(texto.Text),int.Parse(texto_2.Text),int.Parse(texto_3.Text));
                form.Close();
                Views.Saldo.listarSaldo();
                };


            Button SairAlmoxarifadoButton = new Button();
            SairAlmoxarifadoButton.Text = "Sair";
            SairAlmoxarifadoButton.Top = 360;
            SairAlmoxarifadoButton.Left = 220;
            SairAlmoxarifadoButton.Width = 60;
            SairAlmoxarifadoButton.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(label_1);
            form.Controls.Add(texto);
            form.Controls.Add(texto_2);
            form.Controls.Add(texto_3);
            form.Controls.Add(SairAlmoxarifadoButton);
            form.Controls.Add(CadastraAlmoxarifadoButton);
            form.ShowDialog();
      
        }


        public static void alterarSaldo (int id){
            
     

            Form form = new Form();
            form.Text = "Saldo";
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
            label_1.Text = "Alterar Saldo";
            label_1.Top = 10;
            label_1.Left = 200;
            label_1.Width = 300;

            


            Label nameLabel = new Label();
            nameLabel.Text = "Id produto";
            nameLabel.Location = new Point(100, 30);
            nameLabel.AutoSize = true;
            form.Controls.Add(nameLabel);


            TextBox texto = new TextBox();
            texto.Top = 70;
            texto.Left = 100;
            texto.Width = 300;

            Label nameLabel_1 = new Label();
            nameLabel_1.Text = "Id Almoxarifado";
            nameLabel_1.Location = new Point(100, 110);
            nameLabel_1.AutoSize = true;
            form.Controls.Add(nameLabel_1);


            TextBox texto_2 = new TextBox();
            texto_2.Top = 140;
            texto_2.Left = 100;
            texto_2.Width = 300;

            Label nameLabel_2 = new Label();
            nameLabel_2.Text = "Quantidade";
            nameLabel_2.Location = new Point(100, 180);
            nameLabel_2.AutoSize = true;
            form.Controls.Add(nameLabel_2);


            TextBox texto_4 = new TextBox();
            texto_4.Top = 210;
            texto_4.Left = 100;
            texto_4.Width = 300;
            
            

            Button CadastraAlmoxarifadoButton = new Button();
            CadastraAlmoxarifadoButton.Text = "Altera";
            CadastraAlmoxarifadoButton.Top = 360;
            CadastraAlmoxarifadoButton.Left = 300;
            CadastraAlmoxarifadoButton.Width = 60;
            CadastraAlmoxarifadoButton.Click += (sender, e) => { 
                Controllers.Saldo.alterarSaldos(id, int.Parse(texto.Text), int.Parse(texto.Text), int.Parse(texto_4.Text)); 
                form.Hide();
                form.Close();
                Views.Saldo.listarSaldo();

            };


            Button SairAlmoxarifadoButton = new Button();
            SairAlmoxarifadoButton.Text = "Sair";
            SairAlmoxarifadoButton.Top = 360;
            SairAlmoxarifadoButton.Left = 220;
            SairAlmoxarifadoButton.Width = 60;
            SairAlmoxarifadoButton.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(texto_2);
            form.Controls.Add(label_1);
            form.Controls.Add(texto_4);
            form.Controls.Add(texto);
            form.Controls.Add(SairAlmoxarifadoButton);
            form.Controls.Add(CadastraAlmoxarifadoButton);
            form.ShowDialog();
      
        }



        public static void excluirSaldo(int id)
                    {
                        
                                DialogResult result = MessageBox.Show($"Você deseja excluir o Saldo {id}?", "Confirmação", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                using var context = new Context();
                                var saldo = context.saldos.Find(id);
                                if (saldo != null)
                                {
                                    context.saldos.Remove(saldo);
                                    context.SaveChanges();
                                    Views.Saldo.listarSaldo();
                                }
                            }
                        else
                        {
                            MessageBox.Show("Nenhum item selecionado.", "Erro");
                        }
        }


         


}
}

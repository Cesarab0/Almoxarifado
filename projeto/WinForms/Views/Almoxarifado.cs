using Controllers;
using Repository;

namespace Views {


    public class Almoxarifado {
    
        public static void listarAlmoxarifado() {
            using var context = new Context();

            Form form = new Form();
            form.Text = "Almoxarifado";
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
           


            var almoxarifados = context.almoxarifados.ToList();


            lista.Columns.Add("Id");
            lista.Columns.Add("Nome");

           
            foreach (var almoxarifado in almoxarifados)
            {
                lista.Items.Add(new ListViewItem(new[] {almoxarifado.Id.ToString(), almoxarifado.nome}));
            }

            
            Button cadastrarAlmoxarifadoButton = new Button();
            cadastrarAlmoxarifadoButton.Text = "Adicionar";
            cadastrarAlmoxarifadoButton.Top = 360;
            cadastrarAlmoxarifadoButton.Left = 10;
            cadastrarAlmoxarifadoButton.Width = 60;
            cadastrarAlmoxarifadoButton.Click += (sender, e) => { Views.Almoxarifado.addAlmoxarifado();};

            Button alterarAlmoxarifadoButton = new Button();
            alterarAlmoxarifadoButton.Text = "Alterar";
            alterarAlmoxarifadoButton.Top = 360;
            alterarAlmoxarifadoButton.Left = 80;
            alterarAlmoxarifadoButton.Width = 60;
            alterarAlmoxarifadoButton.Click += (sender, e) => {
                ListViewItem.ListViewSubItem subItem = lista.SelectedItems[0].SubItems[0];
                string textoSubItem = subItem.Text;
                Views.Almoxarifado.alterarAlmoxarifado(subItem.Text);
                };

            Button excluirButton = new Button();
            excluirButton.Text = "Excluir";
            excluirButton.Top = 360;
            excluirButton.Left = 150;
            excluirButton.Width = 60;
            excluirButton.Click += (sender, e) => {
             ListViewItem.ListViewSubItem subItem = lista.SelectedItems[0].SubItems[0];
                string textoSubItem = subItem.Text;
                 Views.Almoxarifado.excluirAlmoxarifado(int.Parse(textoSubItem));
                 };

            Button SairAlmoxarifadoButton = new Button();
            SairAlmoxarifadoButton.Text = "Sair";
            SairAlmoxarifadoButton.Top = 360;
            SairAlmoxarifadoButton.Left = 220;
            SairAlmoxarifadoButton.Width = 60;
            SairAlmoxarifadoButton.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(cadastrarAlmoxarifadoButton);
            form.Controls.Add(alterarAlmoxarifadoButton);
            form.Controls.Add(excluirButton);
            form.Controls.Add(SairAlmoxarifadoButton);
            form.Controls.Add(lista);
            form.Controls.Add(lista);
            form.ShowDialog();




        }





         public static void addAlmoxarifado (){
            
    

            Form form = new Form();
            form.Text = "Almoxarifados";
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
            label_1.Text = "Cadastrar almoxarifado";
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
     

        
            Button CadastraAlmoxarifadoButton = new Button();
            CadastraAlmoxarifadoButton.Text = "Cadastrar";
            CadastraAlmoxarifadoButton.Top = 360;
            CadastraAlmoxarifadoButton.Left = 300;
            CadastraAlmoxarifadoButton.Width = 60;
            CadastraAlmoxarifadoButton.Click += (sender, e) => { 
                Controllers.Almoxarifado.criarAlmozarifado(new Models.Almoxarifado(texto.Text)); 
                form.Close();
                Views.Almoxarifado.listarAlmoxarifado();
                };


            Button SairAlmoxarifadoButton = new Button();
            SairAlmoxarifadoButton.Text = "Sair";
            SairAlmoxarifadoButton.Top = 360;
            SairAlmoxarifadoButton.Left = 220;
            SairAlmoxarifadoButton.Width = 60;
            SairAlmoxarifadoButton.Click += (sender, e) => { form.Close(); };

            form.Controls.Add(label_1);
            form.Controls.Add(texto);
            form.Controls.Add(SairAlmoxarifadoButton);
            form.Controls.Add(CadastraAlmoxarifadoButton);
            form.ShowDialog();
      
        }


        public static void alterarAlmoxarifado (string id){
            
          

            Form form = new Form();
            form.Text = "Almoxarifado";
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
            label_1.Text = "Alterar Almoxarifado";
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
            
            

            Button CadastraAlmoxarifadoButton = new Button();
            CadastraAlmoxarifadoButton.Text = "Altera";
            CadastraAlmoxarifadoButton.Top = 360;
            CadastraAlmoxarifadoButton.Left = 300;
            CadastraAlmoxarifadoButton.Width = 60;
            CadastraAlmoxarifadoButton.Click += (sender, e) => { 
                Controllers.Almoxarifado.alterarAlmoxarifados(int.Parse(id), texto.Text); 
                form.Hide();
                form.Close();
                Views.Almoxarifado.listarAlmoxarifado();
                };


            Button SairAlmoxarifadoButton = new Button();
            SairAlmoxarifadoButton.Text = "Sair";
            SairAlmoxarifadoButton.Top = 360;
            SairAlmoxarifadoButton.Left = 220;
            SairAlmoxarifadoButton.Width = 60;
            SairAlmoxarifadoButton.Click += (sender, e) => { form.Close(); };

        
            form.Controls.Add(label_1);
            form.Controls.Add(texto);
            form.Controls.Add(SairAlmoxarifadoButton);
            form.Controls.Add(CadastraAlmoxarifadoButton);
            form.ShowDialog();
      
        }



        

                    public static void excluirAlmoxarifado(int id)
                    {
                        
                                DialogResult result = MessageBox.Show($"Você deseja excluir o almoxarifado {id}?", "Confirmação", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                using var context = new Context();
                                var almoxarifado = context.almoxarifados.Find(id);
                                if (almoxarifado != null)
                                {
                                    context.almoxarifados.Remove(almoxarifado);
                                    context.SaveChanges();
                                    Views.Almoxarifado.listarAlmoxarifado();
                                }
                            }
                        else
                        {
                            MessageBox.Show("Nenhum item selecionado.", "Erro");
                        }
                    }

                    


          
        


    }
}
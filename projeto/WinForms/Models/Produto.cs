using System;
using Repository;

namespace Models {


    public class Produto {
        public int Id {get ; set;}
        public string nome {get ; set;}
        public float preco {get ; set;}

        public ICollection<Saldo> Saldos { get; set; }
        public Produto() {
            
        }


        public Produto(string nome, float preco) {
            this.Id = Id;
            this.nome = nome;
            this.preco = preco;
            Saldos = new HashSet<Saldo>();

        }

        public void cadastrarProduto(string Nome, float Preco)
        {
            using var context = new Context();
            var produto = new Produto { nome = Nome, preco = Preco };
            context.produtos.Add(produto);
            context.SaveChanges();
        }



       public static void alterarProduto(int id, string novoNome, float preco)
        {
            using var context = new Context();
            var produto = context.produtos.Find(id);
            if (produto != null)
            {
                produto.nome = novoNome;
                produto.preco = preco;
                context.SaveChanges();
            }
        }
        
        
        


        
    }

}
using Models;
using Repository;

namespace Controllers {


    public class Produto {
       

        public static void criarProduto(Models.Produto produto) {
            using var context = new Context();
            var produtos = new Models.Produto(produto.nome, produto.preco);
            produtos.cadastrarProduto(produto.nome, produto.preco);
        }


        public static void alterarProdutos(int id, string nome, float preco) {
            Models.Produto.alterarProduto(id, nome, preco);
        }
        
        
        /*

        public static void excluirProdutos(int id) {
            Models.Produto.ExcluirProduto(id);
        }*/
    }

}
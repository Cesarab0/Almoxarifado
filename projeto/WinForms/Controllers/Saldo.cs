using Models;
using Repository;

namespace Controllers {


    public class Saldo {

        public static void criarSaldo(int produto_id, int almoxarifado_id, int quantidade) {
            new Models.Saldo(produto_id, almoxarifado_id,quantidade);
        }

        

        public static void alterarSaldos(int id, int id_p, int id_a, int quantidade) {
            Models.Saldo.alterarSaldo(id, id_p, id_a, quantidade);
        }

      
/*
        public static void excluirSaldos(int id) {
            Models.Saldo.ExcluirSaldos(id);
        }
    }

}*/
    }
}
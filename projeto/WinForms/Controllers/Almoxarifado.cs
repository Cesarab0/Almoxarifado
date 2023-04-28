using Models;
using Repository;

namespace Controllers {


    public class Almoxarifado {

        public static void criarAlmozarifado(Models.Almoxarifado almozarifado) {
            Models.Almoxarifado.cadastrarAlmoxarifado(almozarifado.nome);
        }

        

        public static void alterarAlmoxarifados(int id, string nome) {
            Models.Almoxarifado.alterarAlmoxarifado(id, nome);
        }

       
    }

}

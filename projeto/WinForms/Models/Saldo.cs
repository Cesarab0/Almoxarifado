using System;
using Repository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {

    public class Saldo {
        public int Id { get; set; }
        public int produto_id { get; set; }
        public int almoxarifado_id { get; set; }
        public int quantidade { get; set; }

        [ForeignKey("produto_id")]
        public virtual Produto Produto { get; set; }
        [ForeignKey("almoxarifado_id")]
        public virtual Almoxarifado Almoxarifado { get; set; }

        public Saldo() {
            
        }

        public Saldo(int produtoid, int almoxarifadoid, int quantidade) {
           this.Id = Id;
           this.produto_id = produtoid;
           this.almoxarifado_id = almoxarifadoid;
           this.quantidade = quantidade;

           using var context = new Context();
           context.Add(this);
           context.SaveChanges();


        }

        public void cadastraSaldo(int produtoId, int almoxarifadoId, int quantidade) {     
          new Saldo { produto_id = produtoId, almoxarifado_id = almoxarifadoId, quantidade = quantidade };
        }


        public static void alterarSaldo(int id, int id_p, int id_a, int quantidade)
        {
            using var context = new Context();
            var saldo = context.saldos.Find(id);
            if (saldo != null)
            {
                saldo.Id = id;
                saldo.produto_id = id_p;
                saldo.almoxarifado_id = id_a;
                saldo.quantidade = quantidade;
                context.SaveChanges();
            }
        }

    }
}

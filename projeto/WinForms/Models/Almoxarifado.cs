using System;
using Microsoft.EntityFrameworkCore;
using Repository;


namespace Models {


    public class Almoxarifado {
        public int Id {get ; set;}
        public string nome{get ; set;}

    
        public ICollection<Saldo> Saldos { get; set; }
 

            public Almoxarifado() {
            }


        public Almoxarifado( string nome) {
            this.Id = Id;
            this.nome = nome;
            Saldos = new HashSet<Saldo>();
    
        }

            
        public static void cadastrarAlmoxarifado(string nome)
        {
            using var context = new Context();
            var almoxarifado = new Almoxarifado { nome = nome };
            context.almoxarifados.Add(almoxarifado);
            context.SaveChanges();
        }


        
        

       public static void alterarAlmoxarifado(int id, string novoNome)
        {
            using var context = new Context();
            var almoxarifado = context.almoxarifados.Find(id);
            if (almoxarifado != null)
            {
                almoxarifado.nome = novoNome;
                context.SaveChanges();
            }
        }


       
        
    }

}
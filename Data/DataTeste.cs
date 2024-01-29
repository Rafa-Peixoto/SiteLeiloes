using SiteLeiloes.Models;

namespace SiteLeiloes.Data
{
    public class DataTeste
    {
        public List<Leilao> Leiloes { get; set; }
        public List<Utilizador> Users { get; set; }
        public List<Carro> Carros { get; set; }
        public List<LeilaoFavorito> LeiloesFav { get; set; }
        public List<Venda> Vendas { get; set; }
        public List<Administrador> Admin { get; set; }

        public DataTeste() // Construtor
        {
            // Crie a lista de carros primeiro para que possamos referenciá-los nos leilões.
            InicializarCarros();
            InicializarLeiloes();
            //InicializarUsuarios();
            InicializarLeiloesFavoritos();
            InicializarVendas();
            InicializarAdministradores();

            // Associe os carros aos leilões.
            AssociarCarrosALeiloes();
            AssociarLeiloesALeiloesFavoritos();
            AssociarCarrosAVendas();
        }

        private void InicializarCarros()
        {
            Carros = new List<Carro>
            {
                new Carro (1,2,"Lamborghini" ,"Urus V8",2019 ,16600 ,"novo" , "/images/lamboUrus.png"),
                new Carro (2,2,"Nissan" ,"GT-R",2010,42000 ,"usado" , "/images/gtr.png"),
                new Carro (3,1,"Lamborghini" ,"Huracan",2019 ,15159 ,"novo" , "/images/lamboHuracan.png"),
                new Carro (4,2,"Ferrari" ,"SF90",2023 ,500 ,"novo" , "/images/ferrari.png"),
                new Carro (5,2,"Ferrari" ,"456",1994 ,83000 ,"usado" , "/images/ferrari456.png"),
                new Carro (6,2,"Austin" ,"Mini",1963 ,1000 ,"novo" , "/images/austinMini.png"),
                new Carro (7,2,"Porsche" ,"911",1985 ,153000 ,"usado" , "/images/porsche911.jpg"),
                new Carro (8,1,"BMW" ,"E36 M3",1991 ,123000 ,"usado" , "/images/BMW-E36-M3.jpg")
            };
        }

        private void InicializarLeiloes()
        {
            Leiloes = new List<Leilao>
            {
                new Leilao(1, 500.00f,2, 600.00f,1,8, DateTime.Now, DateTime.Now.AddHours(2), "/images/BMW-E36-M3.jpg"),
                //new Leilao(2, 800.00f,2, 900.00f,1,3, DateTime.Now, DateTime.Now.AddDays(1), "/images/lamboHuracan.png"),
                new Leilao(3, 700.00f,3, 750.00f,2,1, DateTime.Now, DateTime.Now.AddMinutes(30), "/images/lamboUrus.png"),
                new Leilao(4, 700.00f,3, 750.00f,2,2, DateTime.Now, DateTime.Now.AddMinutes(50), "/images/gtr.png"),
                //new Leilao(5, 700.00f,2, 750.00f,2,4, DateTime.Now, DateTime.Now.AddMinutes(30), "/images/ferrari.png"),
                //new Leilao(6, 700.00f,2, 750.00f,2,5, DateTime.Now, DateTime.Now.AddMinutes(20), "/images/ferrari456.png"),
                new Leilao(7, 700.00f,3, 750.00f,2,6, DateTime.Now.AddHours(7), DateTime.Now.AddHours(10), "/images/austinMini.png"),
                new Leilao(8, 700.00f,1, 750.00f,2,7, DateTime.Now.AddHours(2), DateTime.Now.AddHours(5), "/images/porsche911.jpg")
            };
            Leiloes = Leiloes.OrderBy(leilao => leilao.Data_de_fim - DateTime.Now).ToList();
        }

        //private void InicializarUsuarios()
        //{
        //    Users = new List<Utilizador>
        //    {
        //        new Utilizador("user1", "user1", "email1.com"),
        //        new Utilizador("user2", "user2","email2.com"),
        //        new Utilizador("user2", "user2", "email3.com")
        //    };
        //}

        private void InicializarLeiloesFavoritos()
        {
            LeiloesFav = new List<LeilaoFavorito>
            {
                new LeilaoFavorito (3,1),
                new LeilaoFavorito (7,1)
            };
        }

        private void InicializarVendas()
        {
            Vendas = new List<Venda>
            {
                new Venda (1,DateTime.Now.AddDays(-4) ,57550 ,1 ,2 ,5),
                new Venda (1,DateTime.Now.AddDays(-6) ,79550 ,2 ,1 ,4)
            };
        }

        private void InicializarAdministradores()
        {
            Admin = new List<Administrador>
            {
                new Administrador ("admin", "admin")

            };
        }

        private void AssociarCarrosALeiloes()
        {
            foreach (var leilao in Leiloes)
            {
                leilao.Carro = Carros.FirstOrDefault(carro => carro.Id == leilao.CarroId);
            }
        }
        private void AssociarLeiloesALeiloesFavoritos()
        {
            foreach (var favorito in LeiloesFav)
            {
                // Associa o objeto Leilao ao LeilaoFavorito usando LeilaoId
                favorito.Leilao = Leiloes.FirstOrDefault(leilao => leilao.Id == favorito.LeilaoId);
            }
        }
        private void AssociarCarrosAVendas()
        {
            foreach (var venda in Vendas)
            {
                venda.Carro = Carros.FirstOrDefault(carro => carro.Id == venda.CarroId);
            }
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteLeiloes.Models
{
    public class Leilao
    {
        public int Id { get; internal set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "O preço mínimo deve ser positivo.")]
        public float Preco_minimo { get; internal set; }

        public int ClienteId { get; internal set; }
        public int VendedorId { get; internal set; }
        public int CarroId { get; internal set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "O valor deve ser positivo.")]
        public float Valor { get; internal set; }

        [Required]
        public DateTime Data_de_inicio { get; internal set; }

        [Required]
        public DateTime Data_de_fim { get; internal set; }

        [Url]
        public string ImagemUrl { get; set; }

        // Navigation properties
        [ForeignKey("ClienteId")]
        public virtual Utilizador Cliente { get; set; }

        [ForeignKey("VendedorId")]
        public virtual Utilizador Vendedor { get; set; }

        [ForeignKey("CarroId")]
        public virtual Carro Carro { get; set; }

        // Constructor
        public Leilao(int id, float preco_minimo, int clienteId, float valor, int vendedorId, int carroId, DateTime data_de_inicio, DateTime data_de_fim, string imagemUrl)
        {
            Id = id;
            Preco_minimo = preco_minimo;
            ClienteId = clienteId;
            Valor = valor;
            VendedorId = vendedorId;
            CarroId = carroId;
            Data_de_inicio = data_de_inicio;
            Data_de_fim = data_de_fim;
            ImagemUrl = imagemUrl;
        }

    }
}

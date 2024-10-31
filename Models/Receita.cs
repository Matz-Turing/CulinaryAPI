using System.ComponentModel.DataAnnotations;

namespace ReceitasApi.Models
{
    public class Receita
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int TempoPreparo { get; set; } // em minutos
        public decimal Preco { get; set; }

        // Navegação
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}

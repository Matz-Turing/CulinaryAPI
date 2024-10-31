using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReceitasApi.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        // Relação 1:N
        public List<Receita> Receitas { get; set; }
    }
}

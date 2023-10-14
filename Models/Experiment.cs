using ABP_test.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABP_test.Models
{
    public class Experiment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Value { get; set; }

        // Зовнішній ключ для відношення до моделі Token
        public int TokenId { get; set; }

        [ForeignKey("TokenId")]
        public Token Token { get; set; }
    }
}

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
        
        public string TokenName { get; set; }
    }
}

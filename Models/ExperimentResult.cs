using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ABP_test.Model;

namespace ABP_test.Models
{
    public class ExperimentResult
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ResultId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ExperimentId { get; set; }
        public string Value { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ExperimentId")]
        public Experiment Experiment { get; set; }
    }
}

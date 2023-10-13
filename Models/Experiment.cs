using System.ComponentModel.DataAnnotations;

namespace ABP_test.Models
{
    public class Experiment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Options { get; set; }
        public List<ExperimentResult> EstimatedResults { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using ABP_test.Models;

namespace ABP_test.Model
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string DeviceToken { get; set; }

        // Навігаційна властивість для відношення "один-до-багатьох" до моделі Experiment
        public List<Experiment> ExperimentResults { get; set; }
    }

}

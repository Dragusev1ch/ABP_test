using System.ComponentModel.DataAnnotations;
using ABP_test.Models;

namespace ABP_test.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DeviceToken { get; set; }
        public List<ExperimentResult> ExperimentResults { get; set; }
    }
}

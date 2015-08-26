using System.ComponentModel.DataAnnotations;

namespace FF.Models
{
    public class Form
    {
        [Required]
        [Display(Name = "Wall Size")]
        public string WallSize { get; set; }
        [Required]
        [Display(Name = "Current Location")]
        public string RobotStart { get; set; }
        [Required]
        [RegularExpression(@"^[rlfRLF]+$", ErrorMessage = "Value must be R, L or F with no spaces (i.e. 'RFRFLF')")]
        public string Instructions { get; set; }

        public string Output { get; set; }
    }
}
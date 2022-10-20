using System.ComponentModel.DataAnnotations;

namespace assignment_one.DTOs
{
    public class UpdateRespone
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string State { get; set; } = null!;
    }
}
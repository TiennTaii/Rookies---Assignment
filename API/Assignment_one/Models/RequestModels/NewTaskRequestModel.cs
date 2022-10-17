using System.ComponentModel.DataAnnotations;

namespace Assignment_one.Models.RequestModels
{
    public class NewTaskRequestModel
    {
        public Guid Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}
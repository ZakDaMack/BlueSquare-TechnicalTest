using System.ComponentModel.DataAnnotations;
using BlueSquare.Domain.Enums;

namespace BlueSquare.Domain.Entities
{
    public class ClientJob
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public JobStatus Status { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}

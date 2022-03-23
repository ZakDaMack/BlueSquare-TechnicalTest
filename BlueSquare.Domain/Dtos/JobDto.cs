using System.Collections.Generic;
using BlueSquare.Domain.Entities;
using BlueSquare.Domain.Enums;

namespace BlueSquare.Domain.Dtos
{
    public class JobDto
    {
        public string Date { get; set; }

        public string Type { get; set; }

        public JobStatus Status { get; set; }

        public Customer Customer { get; set; }

        public Product Product { get; set; }

        public IEnumerable<Update> Updates { get; set; }
    }
}

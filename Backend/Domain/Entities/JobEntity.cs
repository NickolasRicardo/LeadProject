using LeadApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class JobEntity : EntityBase
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public JobCategory Category { get; set; }
        public JobStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ClientId { get; set; }
        public virtual ClientEntity Client { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClientEntity : EntityBase
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Suburb { get; set; }

        [JsonIgnore]
        public virtual List<JobEntity> Jobs { get; set; }

    }
}

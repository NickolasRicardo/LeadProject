using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadApplication.Domain.Interfaces.Services
{
    public interface ISendEmailService
    {
       Task SendEmail();
    }
}

﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeadApplication.Domain.Query.ListTeste
{
    public class ListTesteQuery : IRequest<string>
    {
        public string Name { get; set; }
    }
}

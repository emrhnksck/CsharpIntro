using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public string customerId { get; set; }
        public String contactName { get; set; }
        public String companyNamme { get; set; }
        public String city { get; set; }
    }
}

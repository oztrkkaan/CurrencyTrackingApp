using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CurrencyDto: IDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string OperationType { get; set; }
    }
}

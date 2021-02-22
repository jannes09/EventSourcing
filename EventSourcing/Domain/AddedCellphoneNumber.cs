using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AddedCellphoneNumber:DomainEvent
    {
        public string CellphoneNumber { get; set; }
    }
}

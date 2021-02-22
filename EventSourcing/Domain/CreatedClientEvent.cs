using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CreatedClientEvent : DomainEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

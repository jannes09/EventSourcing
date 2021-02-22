using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string CellphoneNumber { get; set; }

        public List<DomainEvent> EventsThatHaveHappened { get; private set; } = new List<DomainEvent>();
        public Client(){}
        public Client(Guid id, string name, string surname)
        {
            var createdclientevent = new CreatedClientEvent() { Id = id, Name = name, Surname = surname };
            EventsThatHaveHappened.Add(createdclientevent);
            Apply(createdclientevent);
        }

        public void AddCellphoneNumber(string cellphonenumber)
        {
            var addedCellphoneNumberEvent = new AddedCellphoneNumber() { CellphoneNumber = cellphonenumber };
            EventsThatHaveHappened.Add(addedCellphoneNumberEvent);
            Apply(addedCellphoneNumberEvent);
        }
        public void Apply(CreatedClientEvent createdclientevent)
        {
            Id = createdclientevent.Id;
            Name = createdclientevent.Name;
            Surname = createdclientevent.Surname;
        }
        public void Apply(AddedCellphoneNumber addedCellphoneNumber)
        {
            CellphoneNumber = addedCellphoneNumber.CellphoneNumber; 
        }
    }
}

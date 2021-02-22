using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Core
{
    public class CreateClientHandler
    {
        private readonly IEventStore eventStore;
        public CreateClientHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }
        public void Handle(Guid id, string name, string surname)
        {
            var client = new Client(id, name, surname);

            eventStore.Save(client);
        }
    }
}

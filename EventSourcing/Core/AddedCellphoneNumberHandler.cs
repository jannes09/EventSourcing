using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class AddCellphoneNumberHandler
    {
        private readonly IEventStore eventStore;
        public AddCellphoneNumberHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }
        public void Handle(string name, string cellphonenumber)
        {
            var client = eventStore.Get(name);
            client.AddCellphoneNumber(cellphonenumber);

            eventStore.Save(client);
        }
    }
}

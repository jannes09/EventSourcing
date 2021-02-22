using System;
using System.Linq;
using Core;
using Domain;
using Infrastructure;

namespace Command
{
    class Program
    {
        static SQL sqlDatabase = new SQL();
        static Elastic elastic = new Elastic();
        static EventStore eventstore;
        static void Main(string[] args)
        {
            //command
            eventstore = new EventStore();
            eventstore.NewEventAppeared += EventAppeared;

            var handler = new CreateClientHandler(eventstore);

            handler.Handle(Guid.NewGuid(), "James", "Ventura");


            //query
            var client =  sqlDatabase.tblClients.FirstOrDefault(x => x.Name == "James");
            var client1 = sqlDatabase.tblClients.FirstOrDefault(x => x.Name == "James");

            var cellHandler = new AddCellphoneNumberHandler(eventstore);
            cellHandler.Handle("James", "072");

            client = sqlDatabase.tblClients.FirstOrDefault(x => x.Name == "James");
        }
        //processor
        private static void EventAppeared(DomainEvent domainEvent)
        {
            
            if (domainEvent is CreatedClientEvent)
            {
                var clientCreatedEvent = (CreatedClientEvent)domainEvent;
                var client = new Client();
                client.Apply(clientCreatedEvent);

                sqlDatabase.tblClients.Add(new Client());
                elastic.tblClients.Add(client);
            }else if(domainEvent is AddedCellphoneNumber)
            {
                var addedcellphonennumberevent = (AddedCellphoneNumber)domainEvent;
                var client = eventstore.Get("James");
                client.Apply(addedcellphonennumberevent);
                var sqlClient = sqlDatabase.tblClients.FirstOrDefault(x => x.Name == "James");
                sqlClient = client;
                sqlDatabase.tblClients.Remove(sqlClient);
                sqlDatabase.tblClients.Add(client);
            }

        }
    }
}

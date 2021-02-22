using Domain;
using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class EventStore : IEventStore
    {
        public List<DomainEvent> Events { get; set; } = new List<DomainEvent>();

        public Action<DomainEvent> NewEventAppeared;
        public void Save(Client client)
        {
            Events.AddRange(client.EventsThatHaveHappened);
            foreach (var ev in client.EventsThatHaveHappened)
            {
                NewEventAppeared(ev);
            }
        }

        public Client Get(string name)
        {
            foreach (var ev in Events)
            {
                if (ev is CreatedClientEvent)
                {
                    var eve = (CreatedClientEvent)ev;
                    if (eve.Name==name)
                    {
                        var client = new Client();
                        client.Apply(eve);

                        return client;
                    }
                }
            }
            return null;
        }
    }
}

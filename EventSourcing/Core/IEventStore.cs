using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Core
{
    public interface IEventStore
    {
        void Save(Client client);
        Client Get(string name); 
    }
}

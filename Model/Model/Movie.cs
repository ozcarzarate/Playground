using System.Collections.Generic;

namespace DomainModel.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Client> Clients { get; set; }
    }
}


using System.Collections.Generic;

namespace DomainModel.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
    }
}

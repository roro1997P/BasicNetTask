using Domain.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Heroes
{
    public class Hero
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Thumbnail Thumbnail { get; private set; }
        public string ResourceURI { get; private set; }

        public Hero() { }

        public Hero(int id, string name, string description, Thumbnail thumbnail, string resourceURI)
        {
            Id = id;
            Name = name;
            Description = description;
            Thumbnail = thumbnail;
            ResourceURI = resourceURI;
        }

        public void Update(string name, string description, Thumbnail thumbnail, string resourceURI)
        {
            Name = name;
            Description = description;
            Thumbnail = thumbnail;
            ResourceURI = resourceURI;
        }
    }
}

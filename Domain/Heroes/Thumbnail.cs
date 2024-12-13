using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Heroes
{
    public class Thumbnail
    {
        public string Path { get; private set; }
        public string Extension { get; private set; }

        public Thumbnail(string path, string extension)
        {
            Path = path;
            Extension = extension;
        }

        public void Update(string path, string extension)
        {
            Path = path;
            Extension = extension;
        }
    }
}

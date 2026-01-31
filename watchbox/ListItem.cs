using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchbox
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }

        public override string ToString()
        {
            return IsPublic ? Name + " 🌍" : Name + " 🔒";
        }
    }
}

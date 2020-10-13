using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure.Items
{
    abstract class Item
    {
        protected String name;
        protected String description;

        public String GetName()
        {
            return this.name;
        }

        public String GetDescription()
        {
            return this.description;
        }
    }
}
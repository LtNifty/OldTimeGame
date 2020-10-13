using System;
using System.Linq;

namespace textAdventure.Commands
{
    class PutCommand : Command
    {
        public PutCommand()
        {
            this.triggerWords = new[] { "put" };
            this.cmdParameters = new[] { "[item] in [item]" };
            this.separators.Add("in");
        }

        public override void Execute(string input)
        {
            foreach (string str in input.Split(this.GetSeparators(), StringSplitOptions.None).ToList())
            {
                string obj = str.Trim();

                if (obj.Equals(""))
                    continue;

                Console.WriteLine(obj);
            }
        }
    }
}
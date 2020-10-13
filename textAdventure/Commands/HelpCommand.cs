using System;
using System.Linq;

namespace textAdventure.Commands
{
    class HelpCommand : Command
    {
        public HelpCommand()
        {
            this.triggerWords = new[] { "help" };
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
using System;
using System.Linq;

namespace textAdventure.Commands
{
    class OptionsCommand : Command
    {
        public OptionsCommand()
        {
            this.triggerWords = new[] { "options" };
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
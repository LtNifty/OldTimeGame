using System;
using System.Linq;

namespace textAdventure.Commands
{
    class OpenCommand : Command
    {
        public OpenCommand()
        {
            this.triggerWords = new[] { "open" };
            this.cmdParameters = new[] { "[item]" };
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
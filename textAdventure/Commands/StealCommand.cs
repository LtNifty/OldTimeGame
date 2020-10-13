using System;
using System.Linq;

namespace textAdventure.Commands
{
    class StealCommand : Command
    {
        public StealCommand()
        {
            this.triggerWords = new[] { "steal" };
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
using System;
using System.Linq;

namespace textAdventure.Commands
{
    class UseCommand : Command
    {
        public UseCommand()
        {
            this.triggerWords = new[] { "use" };
            this.cmdParameters = new[] { "[item] on [item]" };
            this.separators.Add("on");
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
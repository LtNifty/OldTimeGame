using System;
using System.Linq;

namespace textAdventure.Commands
{
    class ShowCommand : Command
    {
        public ShowCommand()
        {
            this.triggerWords = new[] { "show" };
            this.cmdParameters = new[] { "[person] [item]" };
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
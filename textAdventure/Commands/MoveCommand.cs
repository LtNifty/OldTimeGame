using System;
using System.Linq;

namespace textAdventure.Commands
{
    class MoveCommand : Command
    {
        public MoveCommand()
        {
            this.triggerWords = new[] { "move", "go" };
            this.cmdParameters = new[] { "[direction]" };
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
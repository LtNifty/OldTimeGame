using System;
using System.Linq;

namespace textAdventure.Commands
{
    class HitCommand : Command
    {
        public HitCommand()
        {
            this.triggerWords = new[] { "hit", "attack" };
            this.cmdParameters = new[] { "[mob/person] (with (item))" };
            this.separators.Add("with");
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
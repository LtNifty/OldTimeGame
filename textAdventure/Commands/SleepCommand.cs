using System;
using System.Linq;

namespace textAdventure.Commands
{
    class SleepCommand : Command
    {
        public SleepCommand()
        {
            this.triggerWords = new[] { "sleep" };
            this.cmdParameters = new[] { "(on bed, on ground)" };
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
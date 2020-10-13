using System;
using System.Linq;

namespace textAdventure.Commands
{
    class AskCommand : Command
    {
        public AskCommand()
        {
            this.triggerWords = new[] { "ask", "question" };
            this.cmdParameters = new[] { "[person] about [anything]" };
            this.separators.Add("about");
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
using System;
using System.Linq;

namespace textAdventure.Commands
{
    class ExamineCommand : Command
    {
        public ExamineCommand()
        {
            this.triggerWords = new[] { "examine" };
            this.cmdParameters = new[] { "[item/person]" };
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
using System;
using System.Linq;

namespace textAdventure.Commands
{
    class LookCommand : Command
    {
        public LookCommand()
        {
            this.triggerWords = new[] { "look" };
        }

        public override void Execute(string input)
        {
            // Program.chara.GetLocation().GetDescription()
            Console.WriteLine("Write location shit here");
        }
    }
}
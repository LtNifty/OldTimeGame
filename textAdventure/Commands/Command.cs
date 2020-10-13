using System;
using System.Collections.Generic;

namespace textAdventure.Commands
{
    abstract class Command
    {
        protected String[] triggerWords = new String[0];
        protected String[] cmdParameters;
        protected List<String> separators;

        public Command()
        {
            this.separators = new List<String>(triggerWords);
            this.separators.AddRange(new[] { ",", "and" });
        }

        public String[] GetTriggerWords()
        {
            return this.triggerWords;
        }

        // it looks fucked but the Split
        // method requires a String[] not
        // a String list
        public String[] GetSeparators()
        {
            return this.separators.ToArray();
        }

        public String[] GetCmdParameters()
        {
            return this.cmdParameters;
        }

        public abstract void Execute(string input);
    }
}
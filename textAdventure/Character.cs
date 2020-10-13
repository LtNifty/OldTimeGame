using System.Collections.Generic;

namespace textAdventure
{
    class Character
    {
        private string name;
        private Dictionary<string, int> skills = new Dictionary<string, int>();
        private Dictionary<string, int> proficiencies = new Dictionary<string, int>();

        public Character(string name, string race)
        {
            this.name = name;
            PopulateSkillsList();
            PopulateProficiencies();
            // prayer is a untrainable stat probably makes the most sense
        }

        public string GetName()
        {
            return this.name;
        }

        public KeyValuePair<string, int> FindSkill(string skillName)
        {
            foreach (KeyValuePair<string, int> skill in this.skills)
                if (skill.Key.ToLower().Equals(skillName.ToLower()))
                    return skill;
            return new KeyValuePair<string, int>(null, 0);
        }

        private void PopulateSkillsList()
        {
            /*
             * If a skill requies the same type of action,
             * then it is not a skill. Mining is not a trainable
             * skill because once you know how to mine a rock, you
             * know how to mine.
             * 
             * You dont know how to craft everything, cook everything, fish
             * everything, hunt everything, etc.
             */
            skills.Add("Agility", 0); // affects evasion chance and shortcut eligability
            skills.Add("Cooking", 0); // affects burning chance and cookable food types
            skills.Add("Crafting", 0); // affects 
            skills.Add("Herbalism", 0); // affects potencies and duration and available tiers
            skills.Add("Magic", 0); // determines accuracy, spell type determines dmg
            skills.Add("Smithing", 0);
            skills.Add("Strength", 0); // proficiency affects accuracy, strength affects dmg
        }

        private void PopulateProficiencies()
        {
            proficiencies.Add("OneHandedWeapons", 1);
            proficiencies.Add("TwoHandedWeapons", 1);
            proficiencies.Add("Polearms", 1);
            proficiencies.Add("Archery", 1); // affects accuracy, arrow type affects damage
            proficiencies.Add("Crossbows", 1);
            proficiencies.Add("Throwables", 1);
            proficiencies.Add("Firearms", 1);
        }
    }
}
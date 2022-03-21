using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Isekai
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1, 99)]
        public int level;
        public CharacterClass characterClass;
        public Progression progression;
        public Experience experience;
        private void Awake()
        {
            experience = GetComponent<Experience>();
        }
        public float GetStat(Stat stat)
        {
            return progression.GetStat(stat, characterClass, level);
        }

        public void CheckLevel()
        {
            if (experience == null) return;
            if(experience.CurrentExperience() > GetStat(Stat.ExperienceToLevelUp))
            {
                level++;
                print("Leveled Up");
            }
        }
    }
}

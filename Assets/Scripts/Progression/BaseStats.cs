using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Isekai
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1, 99)]
        public int level;
        public CharacterClass characterClass;
        public Progression progression;
        public Experience experience;
        public static Action onLevelUp;
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
                onLevelUp.Invoke();
                var currentExp = experience.CurrentExperience();    
                currentExp = experience.CurrentExperience();
            }
        }
    }
}

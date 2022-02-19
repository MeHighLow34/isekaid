using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Progression/Make a New Progression", order = 2)]
    public class Progression : ScriptableObject
    {
        [SerializeField] ProgressionCharacterClass[] classes;
        Dictionary<CharacterClass, Dictionary<Stat, float[]>> lookUpTable;
        [System.Serializable]
        class ProgressionCharacterClass
        {
            public CharacterClass characterClass;
            public ProgressionStat[] stats;
        }
        [System.Serializable]
        class ProgressionStat
        {
            public Stat stat;
            public float[] level;
        }


        public float GetStat(Stat stat,CharacterClass characterClass ,int level)
        {
            BuildLookUp();
            return lookUpTable[characterClass][stat][level - 1];   
        }


        private void BuildLookUp()
        {
            if (lookUpTable != null) return;
            lookUpTable = new Dictionary<CharacterClass,Dictionary<Stat, float[]>>();   
            foreach(ProgressionCharacterClass progressionCharacterClass in classes)
            {
                Dictionary<Stat, float[]> statlookUp = new Dictionary<Stat, float[]>();
                foreach(ProgressionStat progressionStat in progressionCharacterClass.stats)
                {
                    statlookUp[progressionStat.stat] = progressionStat.level;
                }
                lookUpTable[progressionCharacterClass.characterClass] = statlookUp; 
            }
        }


    }
}

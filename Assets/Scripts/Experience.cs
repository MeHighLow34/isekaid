using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class Experience : MonoBehaviour
    {
        [Header("Dependencies")]
        public BaseStats baseStats;
        [Header("Experience")]
        public float experiencePoints;
        private void Awake()
        {
            baseStats = GetComponent<BaseStats>();  
        }

        public void GainExp(float experienceToGain)
        {
            experiencePoints += experienceToGain;
            baseStats.CheckLevel();
        }

        public float CurrentExperience()
        {
            return experiencePoints;
        }
    }
}

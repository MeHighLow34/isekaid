using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class AttackAction : ScriptableObject
    {
        public string animationName;
        public bool canDoCombo;
        public float recoveryTime;
        public float distanceRequirement;
    }
}

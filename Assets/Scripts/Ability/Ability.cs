using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class Ability : MonoBehaviour
    {
        public string abilityName;
        [TextArea]
        public string abilityDescription;
        public string abilityAnimationString;
        public Sprite icon;
        [Header("Time Properties")]
        public float timeLimit;
        public bool canUse;
        public float time;
        public bool beingUsed;
        [Header("Animation")]
        public AnimationManager animationManager;
        public AbilityIntermediary abilityIntermediary;
        public virtual void UseAbility()
        {
            // here should go what happens when we use this ability
        }
        public virtual void AnimationUse()
        {

        }
    }
}

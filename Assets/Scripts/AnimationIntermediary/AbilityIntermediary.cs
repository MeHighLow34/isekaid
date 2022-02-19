using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Isekai
{
    public class AbilityIntermediary : MonoBehaviour
    {
        public Ability currentAbility;


        public void AbilityUse()
        {
            currentAbility.AnimationUse();
        }
    }
}
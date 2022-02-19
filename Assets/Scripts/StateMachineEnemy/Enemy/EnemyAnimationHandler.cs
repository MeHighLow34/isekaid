using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class EnemyAnimationHandler : MonoBehaviour
    {
        public Animator enemyAnimator;


        public void PlayTargetAnimation(string animation, bool isInteracting)  //Plays the animation we want and whether we want to apply root motion or not
        {
            enemyAnimator.applyRootMotion = isInteracting;
            enemyAnimator.SetBool("isInteracting", isInteracting);
            enemyAnimator.CrossFade(animation, 0.1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Isekai
{
    public class AnimationManager : MonoBehaviour
    {
        public Animator animator;


        public void PlayTargetAnimation(string Animation, bool isInteracting)
        {
            animator.SetBool("isInteracting", isInteracting);
            animator.CrossFade(Animation, 0.02f);
        }
    }
}
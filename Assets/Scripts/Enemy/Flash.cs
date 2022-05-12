using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class Flash : MonoBehaviour
    {
        public SkinnedMeshRenderer renderer;
        public Color newColor;
        public Color originalColor;

        public float flashTimer;
        public bool started;


        private void Update()
        {
            if(started)
            {
                flashTimer -= Time.deltaTime;
                renderer.material.color = newColor;
                if(flashTimer < 0)
                {
                    flashTimer = 1;
                    renderer.material.color = originalColor;
                    started = false;
                }
            }
        }
        // compile


    }
}
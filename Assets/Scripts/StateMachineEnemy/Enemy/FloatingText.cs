using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Isekai
{
    public class FloatingText : MonoBehaviour
    {
        public float disappearTimer;
        public Vector3 offset;
        public Vector3 randomizeIntensity = new Vector3(0.5f, 0, 0);

        private void Start()
        {
            Destroy(gameObject, disappearTimer);

            transform.localPosition += offset;
            transform.localPosition += new Vector3(Random.Range(-randomizeIntensity.x, randomizeIntensity.x),
            Random.Range(-randomizeIntensity.y, randomizeIntensity.y), Random.Range(-randomizeIntensity.z, randomizeIntensity.z));
        }
    }
}

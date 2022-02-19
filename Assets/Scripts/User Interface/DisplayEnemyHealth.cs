using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Isekai
{
    public class DisplayEnemyHealth : MonoBehaviour
    {
        public EnemyHealth health;
        public Slider healthSlider;

        private void Update()
        {
            healthSlider.value = health.GetDecimal();
        }
    }
}
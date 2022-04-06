using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Isekai
{
    public class DisplayLevel : MonoBehaviour
    {
        public TextMeshProUGUI textMesh;
        public BaseStats baseStats;

        private void Update()
        {
            textMesh.text = "Level " + baseStats.level;
        }

    }
}

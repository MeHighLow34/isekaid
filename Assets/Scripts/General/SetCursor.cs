using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Isekai
{
    public class SetCursor : MonoBehaviour
    {
        public Texture2D crosshair;

        private void Start()
        {

            void OnMouseEnter()
            {
                Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.Auto);
            }
        }
    }
}
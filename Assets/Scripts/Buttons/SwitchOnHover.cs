﻿using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class SwitchOnHover : MonoBehaviour
    {
        [SerializeField] private Sprite replaceWith;
        private Sprite startSprite;

        private void Start()
        {
            this.startSprite = GetComponent<Image>().sprite;
        }
        public void MouseEnter()
        {
            this.GetComponent<Image>().sprite = replaceWith;
        }

        public void MouseExit()
        {
            this.GetComponent<Image>().sprite = startSprite;
        }
    }
}

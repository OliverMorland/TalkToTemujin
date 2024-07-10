using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VRMenu
{
    public class CharacterSelectable : MonoBehaviour
    {
        public string characterName = "Genghis Khan";
        public Image characterImage;
        public TMP_Text label;
        public Button button;
        public UnityEvent<CharacterSelectable> OnSelected;
        public float unselectedOpacity = 0.3f;
        bool isSelected = false;

        private void Start()
        {
            button.onClick.AddListener(OnCharacterSelected);
        }

        private void OnCharacterSelected()
        {
            OnSelected.Invoke(this);
            isSelected = true;
        }

        public void Deselect()
        {
            isSelected = false;
            Unhighlight();
        }

        public void Highlight()
        {
            characterImage.color = new Color(1f, 1f, 1f, 1f);
            label.gameObject.SetActive(true);
        }

        public void Unhighlight()
        {
            characterImage.color = new Color(1f, 1f, 1f, unselectedOpacity);
            label.gameObject.SetActive(false);
        }

        public void UnhighlightIfNotSelected()
        {
            if (!isSelected)
            {
                Unhighlight();
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VR_Utilities;

namespace VRMenu
{
    public class CharacterSelector : MonoBehaviour
    {
        public string nextSceneName = "ConversationScene";
        public Button confirmButton;
        public Transform container;
        CharacterSelectable selectedCharacter = null;
        List<CharacterSelectable> characterSelectableList;

        private void Start()
        {
            characterSelectableList = GetCharacterSelectables();
            AddOnSelectedListeners();
            confirmButton.onClick.AddListener(OnStartButtonClicked);
            confirmButton.interactable = false;
            UnhighlightAllSelectables();
        }

        List<CharacterSelectable> GetCharacterSelectables()
        {
            List<CharacterSelectable> list = new List<CharacterSelectable>();
            CharacterSelectable[] characterSelectables = container.GetComponentsInChildren<CharacterSelectable>();
            foreach (CharacterSelectable characterSelectable in characterSelectables)
            {
                list.Add(characterSelectable);
            }
            return list;
        }

        void AddOnSelectedListeners()
        {
            foreach (CharacterSelectable characterSelectable in characterSelectableList)
            {
                characterSelectable.OnSelected.AddListener(OnCharacterSelected);
            }
        }

        private void OnStartButtonClicked()
        {
            ScreenFader.Instance.FadeToOpaqueAndLoadNewScene(nextSceneName);
        }

        void OnCharacterSelected(CharacterSelectable characterSelectable)
        {
            UnhighlightAllSelectables();
            selectedCharacter = characterSelectable;
            characterSelectable.Highlight();
            confirmButton.interactable = true;
            nextSceneName = characterSelectable.characterName;
        }

        void UnhighlightAllSelectables()
        {
            foreach (CharacterSelectable characterSelectable in characterSelectableList)
            {
                characterSelectable.Deselect();
            }
        }
    }
}

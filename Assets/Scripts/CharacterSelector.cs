using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VR_Utilities;

public class CharacterSelector : MonoBehaviour
{
    public string nextSceneName = "ConversationScene";
    public Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        ScreenFader.Instance.FadeToOpaqueAndLoadNewScene();
    }
}

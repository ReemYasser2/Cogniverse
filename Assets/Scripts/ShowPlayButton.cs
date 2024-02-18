using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPlayButton : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playerNameInput.onValueChanged.AddListener(OnNameInputChange);

        // Initially hide the play button
        playButton.gameObject.SetActive(false);
    }

    void OnNameInputChange(string newName)
    {
        // Check if the player has entered a name
        bool hasEnteredName = !string.IsNullOrEmpty(newName);
        // Show or hide the play button based on whether a name is entered
        playButton.gameObject.SetActive(hasEnteredName);
    }

}

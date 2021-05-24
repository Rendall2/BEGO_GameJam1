using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActionOnLevelCompletedButton : MonoBehaviour
{
    Button levelCompletedButton;
    PlayerInputs playerInputScript;
    // Start is called before the first frame update
    void Start()
    {

        levelCompletedButton = gameObject.GetComponentInChildren<Button>();
        levelCompletedButton.onClick.AddListener(OnLevelCompletedButtonTapped);

    }

    // Update is called once per frame

    public void OnLevelCompletedButtonTapped()
    {
        playerInputScript = GameObject.FindWithTag("Player").GetComponent<PlayerInputs>();
        playerInputScript.gameManager.setIsLevelCompleted(false);
        StartCoroutine(playerInputScript.NextLevelCoroutine());
    }
}

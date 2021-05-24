using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActionOnGameOverButton : MonoBehaviour
{
    Button gameOverButton;
    PlayerInputs playerInputScript;
    // Start is called before the first frame update
    void Start()
    {
        
        gameOverButton = gameObject.GetComponentInChildren<Button>();
        gameOverButton.onClick.AddListener(OnRetryButtonTapped);

    }

    // Update is called once per frame

    public void OnRetryButtonTapped()
    {
        playerInputScript = GameObject.FindWithTag("Player").GetComponent<PlayerInputs>();
        playerInputScript.gameManager.setGameOver(false);
        playerInputScript.PlayAgain();
    }

}

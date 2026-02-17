using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    float gameLifeTime;
    [SerializeField] UIManager uiManager;
    [SerializeField] Health playerHealth;
    
    public bool didPlayerDie = true;
    public bool didGameStart = false;
    public bool isPaused = false;

    private void Update()
    {
        UpdateHealthUI();
        CheckForPause();
    }
    private void Start()
    {
        didPlayerDie = false;

        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        while (didPlayerDie == false)
        {
            didGameStart = true;
            yield return null;
        }

        didGameStart = false;
        Debug.Log("Plyaer Died");
        uiManager.PlayerDeathFunction();
    }

    void UpdateHealthUI()
    {
        uiManager.healthBar.value = playerHealth.currentHealthPercent;
    }

    void CheckForPause()
    {

        if (didGameStart == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused == false)
                {
                    uiManager.PauseButton();
                }
                else
                {
                    uiManager.UnPauseButton();
                }

            }
        }
        
    }
}

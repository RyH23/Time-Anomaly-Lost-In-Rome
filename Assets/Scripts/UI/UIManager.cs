using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Pannels")]
    [SerializeField] GameObject startPannel;
    [SerializeField] GameObject startStoryPannel;
    [SerializeField] GameObject settingsPannel;
    [SerializeField] GameObject creditsPannel;
    [SerializeField] GameObject deathPannel;
    [SerializeField] GameObject playerUIPannel;
    [SerializeField] GameObject pauseMenuPannel;

    [Header("Buttons")]
    [SerializeField] Button quitGame;
    [SerializeField] Button startLvlOne;
    [SerializeField] Button settings;
    [SerializeField] Button settingsBackButton;

    [Header("Player UI")]
    public Slider healthBar;

    public void StartButtonFunction()
    {
        startPannel.gameObject.SetActive(false);
        startStoryPannel.gameObject.SetActive(true);
    }

    public void SettingsButtonFunction()
    {
        startPannel.gameObject.SetActive(false);
        settingsPannel.gameObject.SetActive(true);
    }

    public void CreeditsButtonFunction()
    {
        startPannel.gameObject.SetActive(false);
        settingsPannel.gameObject.SetActive(false);
        creditsPannel.gameObject.SetActive(true);
    }

    public void BackToMainMenuFunction()
    {
        settingsPannel.SetActive(false);
        creditsPannel.SetActive(false);
        startPannel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("ArenaLvl2");
    }

    public void PlayerDeathFunction()
    {
        playerUIPannel.gameObject.SetActive(false);
        deathPannel.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("ArenaLvl2");
    }

    public void PauseButton()
    {
        pauseMenuPannel.gameObject.SetActive(true); 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void UnPauseButton()
    {
        pauseMenuPannel.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}

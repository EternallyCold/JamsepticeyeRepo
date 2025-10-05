using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject ControlsMenu;
    public void Pause()
    {
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void Controls()
    {
        PauseMenu.SetActive(false);
        ControlsMenu.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Return()
    {
        PauseMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }
}

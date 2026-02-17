using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Menu References")]
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject howToMenu;

    public void Start()
    {
        GoToStartMenu();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToHowToPlay()
    {
        startMenu.SetActive(false);
        howToMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToStartMenu()
    {
        startMenu.SetActive(true);
        howToMenu.SetActive(false);
    }
}

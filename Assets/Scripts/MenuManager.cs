using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Button References")]
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject howToPlayButotn;
    [SerializeField] private GameObject controlsButton;
    [SerializeField] private GameObject exitButton;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToHowToPlay()
    {

    }

    public void GoToControls()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

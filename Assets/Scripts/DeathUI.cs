using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    private void Update()
    {
        highScoreText.text = "High Score: " + Player.highScore + " Enemies Killed";
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

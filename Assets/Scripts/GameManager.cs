using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AttackButtons attackButtons;
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text enemiesKilled;
    [SerializeField] private TMP_Text sequenceLength;
    [SerializeField] private Slider healthSlider;

    public bool advanceSequence = false;


    private void Update()
    {
        if(advanceSequence)
        {
            IncrementSequenceLength();
            advanceSequence = false;
        }
        
        UpdateEnemiesText();
        UpdateSequenceLength();
        HealthSlider();
    }

    private void IncrementSequenceLength()
    {
        if (attackButtons.sequencesCompleted % 3 == 0 && attackButtons.sequencesCompleted != 0)
        {
            attackButtons.orderSize++;
        }
    }

    public void Death()
    {
        SceneManager.LoadScene("Death");
        if(player.enemiesKilled > Player.highScore)
        {
            Player.highScore = player.enemiesKilled; 
        }
    }

    private void UpdateEnemiesText()
    {
        enemiesKilled.text = "Killed: " + player.enemiesKilled;
    }

    private void UpdateSequenceLength()
    {
        sequenceLength.text = "Sequence Length: " + attackButtons.orderSize;
    }

    private void HealthSlider()
    {
        healthSlider.maxValue = player.maxHealth;
        healthSlider.value = player.health;
    }
}

using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackButtons : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color grayNonHighlight;
    [SerializeField] private Color grayHighlight;
    [SerializeField] private Color grayPressed;
    [SerializeField] private Color greenNonHighlight;
    [SerializeField] private Color greenHighlight;
    [SerializeField] private Color greenPressed;

    [Header("Buttons")]
    [SerializeField] private Button[] buttons;
    [SerializeField] private float wrongFlashLength;
    [SerializeField] private float rightFlashLength;
    [SerializeField] private GameManager gm;
    private int sequenceCount = 0;
    public int orderSize;
    private int[] order;
    private bool[] buttonPressed = new bool[5];
    private bool clearToStartColor = true;
    public int sequencesCompleted = 0;

    private void Update()
    {
        if (sequenceCount == 0)
        {
            order = GenerateOrder(orderSize);
            sequenceCount++;

            for(int i = 0; i < buttonPressed.Length; i++)
            {
                buttonPressed[i] = false; 
            }
        }

        //Going through each button and lighting it green and the rest gray based on the sequence count
        if(clearToStartColor == true)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                ColorBlock cb = buttons[i].colors;
                if (order[sequenceCount - 1] == i)
                {
                    cb.normalColor = greenNonHighlight;
                    cb.highlightedColor = greenHighlight;
                    cb.pressedColor = greenPressed;
                }
                else
                {
                    cb.normalColor = grayNonHighlight;
                    cb.highlightedColor = grayHighlight;
                    cb.pressedColor = grayPressed;
                }
                buttons[i].colors = cb;
            }

        }

        int correctIndex = order[sequenceCount - 1]; 

        //Check if the player pressed the wrong button
        for (int i = 0; i < buttonPressed.Length; i++)
        {
            if (buttonPressed[i] == true && buttonPressed[correctIndex] == false)
            {
                StartCoroutine(WrongAnswerFlash());
                sequenceCount = 0;
            }
        }

        //Check if the player pressed the right button
        if (buttonPressed[correctIndex] == true)
        {
            sequenceCount++;
            buttonPressed[correctIndex] = false;
        }

        if(sequenceCount - 1 == orderSize)
        {
            StartCoroutine(ShotFlash());
            gameObject.GetComponent<Player>().Shoot();
            sequenceCount = 0;
            sequencesCompleted++;
            gm.advanceSequence = true;
        }
    }

    public void ClickButton1()
    {
        buttonPressed[0] = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ClickButton2()
    {
        buttonPressed[1] = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ClickButton3()
    {
        buttonPressed[2] = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ClickButton4()
    {
        buttonPressed[3] = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ClickButton5()
    {
        buttonPressed[4] = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
   
    public IEnumerator WrongAnswerFlash()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        clearToStartColor = false;

        yield return new WaitForSeconds(wrongFlashLength);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }

        clearToStartColor = true;
    }

    public IEnumerator ShotFlash()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            ColorBlock cb = buttons[i].colors;

            cb.normalColor = greenPressed;
            buttons[i].colors = cb;
        }
        clearToStartColor = false;
        yield return new WaitForSeconds(rightFlashLength);

        clearToStartColor = true;
        

    }

    private int[] GenerateOrder(int size)
    {
        int[] order = new int[size];
        for(int i = 0; i < order.Length; i++)
        {
            order[i] = Random.Range(0, 5);
        }
        return order;
    }
}

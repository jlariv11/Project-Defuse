using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysScript : MonoBehaviour
{
    [SerializeField] 
    private Color[] order;
    private Color[] gameColors;
    [SerializeField]
    private Color[] secretOrder;
    [SerializeField] 
    private int patternLength;
    [SerializeField]
    private Image[] gameButtons;
    [SerializeField]
    private GameObject scoreboard;
    [SerializeField]
    private int secretOrderLength = 8;
    private Image[] correctImages;
    private Image[] incorrectImages;
    private int patternIndex;
    private int correct;
    private int incorrect;
    private Color[] currentInput;
    private TimerScript timer;
    // Start is called before the first frame update
    void Start()
    {
        gameColors = new Color[4];
        gameColors[0] = Color.green;
        gameColors[1] = Color.red;
        gameColors[2] = Color.yellow;
        gameColors[3] = Color.blue;
        for(int i = 0; i < gameColors.Length; i++)
        {
            gameButtons[i].color = gameColors[i];
        }
        currentInput = new Color[Mathf.Max(secretOrderLength, patternLength)];
        Transform correctList = scoreboard.transform.GetChild(0).GetChild(0);
        correctImages = new Image[correctList.childCount];
        for(int i = 0; i < correctImages.Length; i++)
        {
            correctImages[i] = correctList.GetChild(i).GetComponent<Image>();
        }
        Transform incorrectList = scoreboard.transform.GetChild(1).GetChild(0);
        incorrectImages = new Image[incorrectList.childCount];
        for (int i = 0; i < incorrectImages.Length; i++)
        {
            incorrectImages[i] = incorrectList.GetChild(i).GetComponent<Image>();
        }
        enableButtons(false);
        createPattern();
        StartCoroutine(showPattern());
        patternIndex = 0;
        correct = 0;
        incorrect = 0;
        GameManager.createSecretOrder(secretOrderLength, gameColors);
        secretOrder = GameManager.secretSimonSaysPattern;
        timer = GameObject.Find("Timer").GetComponent<TimerScript>();
        timer.timeUpEvent.AddListener(() =>{
            enableButtons(false);
        });
    }

    void enableButtons(bool canClick)
    {
        foreach (Image i in gameButtons)
        {
            i.GetComponent<Button>().enabled = canClick;
        }
    }

    void createPattern()
    {
        order = new Color[patternLength];
        for (int i = 0; i < patternLength; i++)
        {
            int index = Random.Range(0, gameColors.Length);
            order[i] = gameColors[index];
        }
    }

    IEnumerator showPattern()
    {
        if(correct >= correctImages.Length || incorrect >= incorrectImages.Length)
        {
            enableButtons(false);
            timer.stop();
            yield break;
        }
        for (int i = 0; i < patternLength; i++)
        {
            yield return new WaitForSeconds(0.75f);
            Image currentImage = getGameImageFromColor(order[i]);
            Color baseColor = currentImage.color;
            Color aColor = new Color(baseColor.r - 0.5f, baseColor.g - 0.5f, baseColor.b - 0.5f);
            currentImage.color = aColor;
            yield return new WaitForSeconds(0.75f);
            currentImage.color = baseColor;
        }
        enableButtons(true);
    }

    private Image getGameImageFromColor(Color c)
    {
        foreach (Image i in gameButtons)
        {
            if (i.color == c)
            {
                return i;
            }
        }
        return null;
    }

    private bool checkValidGame()
    {
        return currentInput[patternIndex - 1].Equals(secretOrder[patternIndex - 1]) || currentInput[patternIndex - 1].Equals(order[patternIndex - 1]);
    }
    public void inputColor(Image color)
    {
        currentInput[patternIndex++] = color.color;
        if (checkValidGame())
        {
            if (checkSecretPattern())
            {
                secretWin();
            }else if (checkPattern())
            {
                showResult(true);
            }
        }
        else
        { 
            showResult(false);
        }
    }

    private bool checkPattern()
    {
        for (int i = 0; i < order.Length; i++)
        {
            if(currentInput[i] == null || currentInput[i] != order[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool checkSecretPattern()
    {
        for (int i = 0; i < secretOrder.Length; i++)
        {
            if (currentInput[i] == null || currentInput[i] != secretOrder[i])
            {
                return false;
            }
        }
        return true;
    }

    private void restart(bool correctAns)
    {
        if (correctAns)
        {
            correct++;
            patternLength++;
        }
        else
        {
            incorrect++;
        }
        enableButtons(false);
        patternIndex = 0;
        createPattern();
        StartCoroutine(showPattern());
    }

    private void showResult(bool correctAns)
    {
        if (correctAns)
        {
            correctImages[correct].color = Color.green;
        }
        else
        {
            incorrectImages[incorrect].color = Color.red;
        }
        restart(correctAns);
    }

    private void secretWin()
    {
        foreach(Image i in correctImages)
        {
            i.color = Color.green;
        }
        correct = correctImages.Length;
        enableButtons(false);
    }

}

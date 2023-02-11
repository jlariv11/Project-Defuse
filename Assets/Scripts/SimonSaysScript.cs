using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysScript : MonoBehaviour
{
    [SerializeField] 
    private Image[] order;
    [SerializeField]
    private Image[] secretOrder;
    [SerializeField] 
    private int patternLength;
    [SerializeField]
    private Image[] colors;
    [SerializeField]
    private GameObject scoreboard;
    [SerializeField]
    private int secretOrderLength = 8;
    private Image[] correctImages;
    private Image[] incorrectImages;
    private int patternIndex;
    private int correct;
    private int incorrect;
    // Start is called before the first frame update
    void Start()
    {
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
        secretOrder = new Image[secretOrderLength];
        createSecretOrder();
    }

    void enableButtons(bool canClick)
    {
        foreach (Image i in colors)
        {
            i.GetComponent<Button>().enabled = canClick;
        }
    }

    void createPattern()
    {
        order = new Image[patternLength];
        for (int i = 0; i < patternLength; i++)
        {
            int index = Random.Range(0, colors.Length);
            order[i] = colors[index];
        }
    }
    void createSecretOrder()
    {
        for (int i = 0; i < secretOrderLength; i++)
        {
            int index = Random.Range(0, colors.Length);
            secretOrder[i] = colors[index];
        }
    }

    IEnumerator showPattern()
    {
        if(correct >= correctImages.Length || incorrect >= incorrectImages.Length)
        {
            enableButtons(false);
            yield break;
        }
        for (int i = 0; i < patternLength; i++)
        {
            yield return new WaitForSeconds(0.75f);
            Image currentImage = order[i];
            Color baseColor = currentImage.color;
            Color aColor = new Color(baseColor.r - 0.5f, baseColor.g - 0.5f, baseColor.b - 0.5f);
            currentImage.color = aColor;
            yield return new WaitForSeconds(0.75f);
            currentImage.color = baseColor;
        }
        enableButtons(true);
    }

    public void inputColor(Image color)
    {
        if (color.color == secretOrder[patternIndex].color)
        {
            patternIndex++;
            if (patternIndex == secretOrderLength)
            {
                secretWin();
            }
        }
        else if (color.color == order[patternIndex].color && patternIndex <= order.Length)
        {
            patternIndex++;
            if (patternIndex == patternLength)
            {
                showResult(true);
            }
        }
        else
        {
            showResult(false);
        }
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

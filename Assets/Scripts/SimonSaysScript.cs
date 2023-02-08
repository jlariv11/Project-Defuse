using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysScript : MonoBehaviour
{
    [SerializeField] 
    private Image[] order;
    [SerializeField] 
    private int patternLength;
    [SerializeField]
    private Image[] colors;
    [SerializeField]
    private Image[] correctMarkers;
    private int patternIndex;
    private int gameIndex;
    // Start is called before the first frame update
    void Start()
    {
        enableButtons(false);
        order = new Image[patternLength];
        createPattern();
        StartCoroutine(showPattern());
        patternIndex = 0;
        gameIndex = 0;
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
        for (int i = 0; i < patternLength; i++)
        {
            int index = Random.Range(0, colors.Length);
            order[i] = colors[index];
        }
        patternLength++;
    }

    IEnumerator showPattern()
    {
        if(gameIndex >= 3)
        {
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
        print(color.color);
        if(color.color == order[patternIndex].color)
        {
            patternIndex++;
            if(patternIndex == patternLength)
            {
                showResult(true);
                patternIndex = 0;
                createPattern();
                StartCoroutine(showPattern());
            }
        }
        else
        {
            showResult(false);
        }
    }

    private void showResult(bool correct)
    {
        if (correct)
        {
            correctMarkers[gameIndex].color = Color.green;
        }
        else
        {
            correctMarkers[gameIndex].color = Color.red;
            enableButtons(false);
            createPattern();
            StartCoroutine(showPattern());
        }
        gameIndex++;
    }

}

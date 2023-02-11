using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverGameScript : MonoBehaviour
{
    [SerializeField]
    private Transform indicators;
    [SerializeField]
    private Transform levers;
    private Image[] indicatorImages;
    [SerializeField]
    private Color[] secretIndicators;
    private LeverScript[] leverScripts;

    // Start is called before the first frame update
    void Start()
    {
        indicatorImages = new Image[indicators.childCount];
        secretIndicators = new Color[indicators.childCount];
        for (int i = 0; i < indicators.childCount; i++)
        {
            indicatorImages[i] = indicators.GetChild(i).GetComponent<Image>();
            indicatorImages[i].color = Random.Range(0, 2) == 0 ? Color.blue : Color.black;
            secretIndicators[i] = Random.Range(0, 2) == 0 ? Color.blue : Color.black;


        }
        leverScripts = new LeverScript[levers.childCount];
        for (int i = 0; i < indicators.childCount; i++)
        {
            leverScripts[i] = levers.GetChild(i).GetComponent<LeverScript>();
        }
    }

    private void deactivateLevers()
    {
        for (int i = 0; i < indicatorImages.Length; i++)
        {
            leverScripts[i].setClickable(false);
        }
    }

    private bool checkSecret()
    {
        for (int i = 0; i < indicatorImages.Length; i++)
        {
            if (secretIndicators[i] != leverScripts[i].getImage().color)
            {
                return false;
            }
        }
        return true;
    }

    public void validate()
    {
        deactivateLevers();
        bool win = true;
        if (!checkSecret())
        {
            for (int i = 0; i < indicatorImages.Length; i++)
            {
                if (indicatorImages[i].color != leverScripts[i].getImage().color)
                {
                    win = false;
                    break;
                }
            }
        }
        for (int i = 0; i < indicatorImages.Length; i++)
        {
            leverScripts[i].getImage().color = win ? Color.green : Color.red;
        }
    }

}

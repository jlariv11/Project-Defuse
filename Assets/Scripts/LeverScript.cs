using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverScript : MonoBehaviour
{
    [SerializeField]
    private bool flicked;
    private Image leverImg;
    private Button leverBtn;

    // Start is called before the first frame update
    void Start()
    {
        flicked = false;
        leverImg = GetComponent<Image>();
        leverBtn = GetComponent<Button>();
    }

    public void flick()
    {
        flicked = !flicked;
        updateState();
    }

    private void updateState()
    {
        if (flicked)
        {
            //leverImg.color = Color.blue;
            leverImg.color = Color.white;
        }
        else
        {
            leverImg.color = Color.black;
        }
    }

    public void setClickable(bool clickable)
    {
        leverBtn.enabled = clickable;
    }

    public Image getImage()
    {
        return leverImg;
    }

}

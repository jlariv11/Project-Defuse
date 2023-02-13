using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstructionsControllerScript : MonoBehaviour
{
    private GameObject[] pages;
    private int currentPage;
    [SerializeField]
    private Transform simonSaysCodeHolder;
    [SerializeField]
    private Image simonSaysColorPrefab;
    [SerializeField]
    private Image leversPrefab;
    [SerializeField]
    private Transform leversCodeHolder;
    [SerializeField]
    private Text codeText;

    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
        pages = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            pages[i] = transform.GetChild(i).gameObject;
        }
        //setSimonSaysPattern();
        //setLeversPattern();
        setCode();
    }

    public void next()
    {
        if((currentPage + 1) >= transform.childCount)
        {
            return;
        }
        pages[currentPage++].SetActive(false);
        pages[currentPage].SetActive(true);
    }

    public void prev()
    {
        if(currentPage - 1 < 0)
        {
            return;
        }
        pages[currentPage--].SetActive(false);
        pages[currentPage].SetActive(true);
    }

    private void setSimonSaysPattern()
    {
        Color[] pattern = GameManager.secretSimonSaysPattern;
        foreach (Color c in pattern)
        {
            Image img = GameObject.Instantiate<Image>(simonSaysColorPrefab);
            img.gameObject.SetActive(true);
            img.transform.SetParent(simonSaysCodeHolder);
            img.color = c;
        }
    }

    private void setLeversPattern()
    {
        Color[] pattern = GameManager.secretLeverPattern;
        foreach (Color c in pattern)
        {
            Image img = GameObject.Instantiate<Image>(leversPrefab);
            img.gameObject.SetActive(true);
            img.transform.SetParent(leversCodeHolder);
            img.color = c;
        }
    }

    private void setCode()
    {
        codeText.text = codeToString(GameManager.secretCode);
    }

    private string codeToString(int[] code)
    {
        string s = "";
        foreach (int i in code)
        {
            s += i;
        }
        return s;
    }
}

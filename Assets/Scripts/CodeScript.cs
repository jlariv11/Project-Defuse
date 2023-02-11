using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeScript : MonoBehaviour
{
    [SerializeField]
    private int nums = 5;
    [SerializeField]
    private int[] code;
    [SerializeField]
    private Text screenText;
    private int[] inputCode;
    private int inputIndex;
    const int MAX_NUMS = 9;
    private bool end;

    // Start is called before the first frame update
    void Start()
    {
        nums = Mathf.Min(nums, MAX_NUMS);
        end = false;
        code = new int[nums];
        inputCode = new int[nums];
        inputIndex = 0;
        screenText.text = inputToString();
        generateCode();
    }

    private void generateCode()
    {
        for(int i = 0; i < code.Length; i++)
        {
            code[i] = Random.Range(1, 10);
            inputCode[i] = 0;
        }

    }

    public void inputNum(int num)
    {
        if(inputIndex >= nums || end)
        {
            return;
        }
        inputCode[inputIndex] = num;
        screenText.text = inputToString();
        inputIndex++;
    }

    public void verify()
    {
        bool win = true;
        for(int i = 0; i < nums; i++){
            if(code[i] != inputCode[i])
            {
                win = false;
                break;
            }
        }
        screenText.color = win ? Color.green : Color.red;
        end = true;
        
    }

    private string inputToString()
    {
        string s = "";
        foreach (int i in inputCode)
        {
            s += i;
        }
        return s;
    }

    public void delete()
    {
        if(inputIndex <= 0)
        {
            return;
        }
        inputIndex--;
        inputCode[inputIndex] = 0;
        screenText.text = inputToString();
    }



}

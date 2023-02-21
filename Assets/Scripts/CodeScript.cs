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
    [SerializeField]
    private Text tempCodeText;
    private int[] inputCode;
    private int inputIndex;
    const int MAX_NUMS = 9;
    private bool end;
    private TimerScript timer;

    // Start is called before the first frame update
    void Start()
    {
        nums = Mathf.Min(nums, MAX_NUMS);
        end = false;
        code = new int[nums];
        inputCode = new int[nums];
        inputIndex = 0;
        screenText.text = codeToString(inputCode);
        for (int i = 0; i < code.Length; i++)
        {
            inputCode[i] = 0;
        }
        GameManager.createCode(code.Length);
        code = GameManager.secretCode;
        tempCodeText.text = codeToString(code);
        timer = GameObject.Find("Timer").GetComponent<TimerScript>();
        timer.timeUpEvent.AddListener(() => { end = true; });
    }

    public void inputNum(int num)
    {
        if(inputIndex >= nums || end)
        {
            return;
        }
        inputCode[inputIndex] = num;
        screenText.text = codeToString(inputCode);
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
        timer.stop();
        
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

    public void delete()
    {
        if(inputIndex <= 0)
        {
            return;
        }
        inputIndex--;
        inputCode[inputIndex] = 0;
        screenText.text = codeToString(inputCode);
    }

}

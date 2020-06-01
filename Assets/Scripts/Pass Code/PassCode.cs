using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public sealed class PassCode : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    [Range(0, 3)] public int spaceBetewnNums = 3;
    public string emptyNumChar = "_";
    public string correctCode = "";
    public UnityAction OnPassAccepted;
    public UnityAction OnPassDenied;
    
    string code = "";

    public int CorrectCodeLength
    {
        get { return correctCode.Length;}
    }

    public int CurrentCodeLength
    {
        get { return code.Length;}
    }

    void Start()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayText.text = "";

        for (int i = 0; i < CorrectCodeLength; i++)
        {
            if (i < CurrentCodeLength)
            {
                displayText.text += code[i];
            } else {
                displayText.text += emptyNumChar;
            }

            displayText.text += new string(' ', spaceBetewnNums);
        }
    }

    void Check()
    {
        if (code == correctCode)
        {
            displayText.text = "Accepted";
            OnPassAccepted?.Invoke();
        } else {
            OnPassDenied?.Invoke();
            displayText.text = "Denied";
        }

        code = "";
    }

    public void AddNum(int num)
    {
        if (CurrentCodeLength < CorrectCodeLength)
        {
            code += num.ToString();
            UpdateDisplay();
        }
        
        if (CurrentCodeLength == CorrectCodeLength)
        {
            Check();
        }
    }

    public void Delete()
    {
        if (CurrentCodeLength > 0)
        {
            code = code.Remove(CurrentCodeLength -1);
            UpdateDisplay();
        }
    }
}

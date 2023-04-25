using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUIController : MonoBehaviour
{
    public TMP_Text timerText;

    public void SetTimer(int newValue){
        timerText.text = newValue.ToString();
    }
}

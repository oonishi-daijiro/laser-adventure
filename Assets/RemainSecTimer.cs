using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RemainSecTimer : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] int sec;
    Timer timer;
    [SerializeField] TextMeshProUGUI timerText;


    private int remainSec;

    void Start()
    {
        timer = gameObject.GetComponent<Timer>();
        remainSec = min * 60 + sec;
        timer.AddPerSecListenner(UpdateTimerText);
    }


    (int, int) Sec2Min(int seconds)
    {
        int min = (seconds - (seconds % 60)) / 60;
        int s = seconds - min * 60;
        return (min, s);
    }

    void UpdateTimerText()
    {
        remainSec--;
        (int min, int sec) = Sec2Min(remainSec);
        timerText.text = $"TIME REMAINS:{min}:{sec}";
    }
}

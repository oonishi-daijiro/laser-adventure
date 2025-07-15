using TMPro;
using UnityEngine;

public class UserIntaface : LaserAdventureGame
{
    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI outTxt;
    private string timerText;
    int remainSec;

    void Start()
    {
        timer.AddPerSecListenner(UpdateTimerText);
        remainSec = GetTimeLimitSec();
    }

    (int, int) Sec2Min(int seconds)
    {
        int min = (seconds - (seconds % 60)) / 60;
        int s = seconds - min * 60;
        return (min, s);
    }

    string FormatLivesAndTimerText()
    {
        return $"{timerText} lives:{GetPlayerLives()}";
    }

    void Update()
    {
        outTxt.text = FormatLivesAndTimerText();
    }

    void UpdateTimerText()
    {
        remainSec--;
        (int min, int sec) = Sec2Min(remainSec);
        timerText = $"TIME REMAINS:{min}:{sec.ToString("00")}";
    }
}

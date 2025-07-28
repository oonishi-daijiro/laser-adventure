using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserIntaface : LaserAdventureGame
{
    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI outTxt;
    private string timerText;
    int remainSec;

    void Start()
    {
        timer.AddPerSecListenner(DecreaseRemainTime);
        remainSec = GetTimeLimitSec();
        timerText = "";
    }


    (int, int) Sec2Min(int seconds)
    {
        int min = (seconds - (seconds % 60)) / 60;
        int s = seconds - min * 60;
        return (min, s);
    }

    string FormatLivesAndTimerText()
    {
        return $"{timerText} \nあと{GetPlayerLives()}回\n スコア:{GetScore()}";
    }

    void Update()
    {
        outTxt.text = FormatLivesAndTimerText();
    }

    void DecreaseRemainTime()
    {
        remainSec--;
        SetRemainTime(remainSec);

        (int min, int sec) = Sec2Min(remainSec);
        timerText = $"タイム:{min}:{sec.ToString("00")}";
    }
}

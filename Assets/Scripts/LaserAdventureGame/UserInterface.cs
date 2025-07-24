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
        timer.AddPerSecListenner(UpdateTimerText);
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
        return $"{timerText} \nlives:{GetPlayerLives()}\n score:{getScore()}";
    }

    void Update()
    {
        // Debug.Log(GetDebugGameState());
        outTxt.text = FormatLivesAndTimerText();
        if (GetGameState() == GameState.GameOver)
        {
            timer.SetTimeout(() =>
                        {
                            Debug.Log("ゲームオーバー");
                            SceneManager.LoadScene("GameOver");
                        }, 3);
            SetGameState(GameState.Yet);
        }
    }

    void UpdateTimerText()
    {
        remainSec--;
        (int min, int sec) = Sec2Min(remainSec);
        timerText = $"TIME REMAINS:{min}:{sec.ToString("00")}";
    }
}

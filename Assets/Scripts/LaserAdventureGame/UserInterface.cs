using System.Collections.Generic;
using Meta.WitAi;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserIntaface : LaserAdventureGame
{
    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI outTxt;
    [SerializeField] GameObject heart;
    private string timerText;
    int remainSec;
    List<GameObject> hearts;

    void Start()
    {
        timer.AddPerSecListenner(DecreaseRemainTime);
        remainSec = GetTimeLimitSec();
        timerText = "";
        hearts = new();
        var heartSize = heart.GetComponent<Renderer>().bounds.size;
        var newPosX = heart.transform.position.x;

        for (int i = 0; i < GetPlayerLives(); i++)
        {
            var h = Instantiate(heart, new Vector3(newPosX, heart.transform.position.y, 3), Quaternion.identity, gameObject.transform);
            newPosX += heartSize.x;
            hearts.Add(h);
        }
    }


    (int, int) Sec2Min(int seconds)
    {
        int min = (seconds - (seconds % 60)) / 60;
        int s = seconds - min * 60;
        return (min, s);
    }

    string FormatLivesAndTimerText()
    {
        return $"{timerText} \n\n スコア:{GetScore()}";
    }

    void Update()
    {
        for (int i = 0; i < defaultLives - GetPlayerLives(); i++)
        {
            if (defaultLives - 1 - i >= 0)
            {
                Destroy(hearts[defaultLives - 1 - i]);
            }
        }
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

using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreDisplay : LaserAdventureGame
{
    public TextMeshProUGUI scoreText;
    int finalScore = GetScore();
    public float countDuration = 2.0f;

    void Start()
    {
        // 初期表示（最終スコア：0）
        scoreText.text = "スコア：0";

        // 1秒後にカウントアップ開始
        Invoke(nameof(ShowFailScore), 1f);
    }

    public void ShowFailScore()
    {
        StartCoroutine(CountScore());
    }

    IEnumerator CountScore()
    {
        int currentScore = 0;
        float elapsed = 0f;

        while (elapsed < countDuration)
        {
            elapsed += Time.deltaTime;
            currentScore = (int)Mathf.Lerp(0, finalScore, elapsed / countDuration);
            scoreText.text = "スコア：" + currentScore.ToString() + (finalScore > GetHighestScore() ? "最高スコア！" : ""); ;
            yield return null;
        }

        // 最終スコア補正
        scoreText.text = "スコア：" + finalScore.ToString();
    }
}

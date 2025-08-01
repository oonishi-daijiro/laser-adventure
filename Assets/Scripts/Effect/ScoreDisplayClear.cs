using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreDisplayClear : LaserAdventureGame
{
    public TextMeshProUGUI scoreText;
    int finalScore = GetScore();

    void Start()
    {
        // 最初はスケール0で非表示のように
        scoreText.transform.localScale = Vector3.zero;

        // 初期テキストを設定
        scoreText.text = "スコア：" + finalScore.ToString() + (finalScore > GetHighestScore() ? "\n最高スコア！" :"");

        // 1秒後にアニメーション表示
        Invoke(nameof(ShowSuccessScore), 1f);
    }

    void ShowSuccessScore()
    {
        // スケール1にアニメーションしながら拡大表示
        scoreText.transform.DOScale(Vector3.one, 0.5f)
            .SetEase(Ease.OutBounce);
    }
}

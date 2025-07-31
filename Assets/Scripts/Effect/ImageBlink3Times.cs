using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class ImageBlink3Times : LaserAdventureGame
{
    [SerializeField] private Image targetImage;

    [Header("Timing Settings")]
    [SerializeField] private float fadeDuration = 0.5f;      // フェードイン・アウトの秒数
    [SerializeField] private float holdDuration = 0.3f;      // 赤く表示している時間
    [SerializeField] private float intervalDuration = 0.3f;  // 点滅間の空白時間

    [Header("Visual Settings")]
    [SerializeField] private Color blinkColor = new Color(0.7f, 0f, 0f); // 控えめな赤
    bool isAlreadyShown = false;

    private bool isBlinking = false;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Gキーを押したら点滅開始（すでに点滅中でなければ）
        if (GetGameState() == GameState.PlayingApproachingPostureLaser && !isAlreadyShown)
        {
            StartCoroutine(BlinkThreeTimes());
            isAlreadyShown = true;
        }
    }

    private IEnumerator BlinkThreeTimes()
    {
        isBlinking = true;

        for (int i = 0; i < 3; i++)
        {
            // フェードイン（0 → 最大透明度）
            yield return StartCoroutine(FadeToAlpha(0.5f));  // 最大透明度0.5

            // 一定時間表示を維持
            yield return new WaitForSeconds(holdDuration);

            // フェードアウト（最大透明度 → 0）
            yield return StartCoroutine(FadeToAlpha(0f));

            // 次の点滅までの空白
            if (i < 2)
                yield return new WaitForSeconds(intervalDuration);
        }

        isBlinking = false;
    }

    private IEnumerator FadeToAlpha(float targetAlpha)
    {
        float startAlpha = targetImage.color.a;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / fadeDuration);
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            targetImage.color = new Color(blinkColor.r, blinkColor.g, blinkColor.b, newAlpha);
            yield return null;
        }

        // 最終値を明示的に設定
        targetImage.color = new Color(blinkColor.r, blinkColor.g, blinkColor.b, targetAlpha);
    }
}

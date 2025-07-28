using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Damage : LaserAdventureGame
{
    [SerializeField] private Image DamageImg;
    [SerializeField] private AudioClip seClip;

    [Header("フラッシュ設定")]
    [SerializeField] private int flashCount = 3;

    [Tooltip("フェードインとフェードアウトにかける時間（秒）")]
    [SerializeField] private float fadeDuration = 0.5f;

    [Tooltip("赤色を維持する時間（秒）")]
    [SerializeField] private float stayDuration = 1.0f;

    [Tooltip("各フラッシュの間隔（秒）")]
    [SerializeField] private float delayBetweenFlashes = 0.1f;

    [Header("シーン遷移設定")]
    [Tooltip("エフェクト完了後の遅延時間（秒）")]
    [SerializeField] private float sceneDelayAfterEffect = 1.0f;

    [Tooltip("遷移先のシーン名")]
    [SerializeField] private string nextSceneName = "NextScene";  // 実際のシーン名に変更する

    private bool isGameOverEffectPlaying = false;

    private readonly Color flashColor = new Color(0.7f, 0f, 0f, 0.7f);
    private readonly Color clearColor = Color.clear;

    void Start()
    {
        DamageImg.color = clearColor;
    }

    void Update()
    {
        if (GetGameState() == GameState.GameOver)
        {
            StartCoroutine(GameOverEffect());
        }
    }

    IEnumerator GameOverEffect()
    {
        isGameOverEffectPlaying = true;

        for (int i = 0; i < flashCount; i++)
        {
            // 効果音再生（フェードイン開始直前）
            if (seClip != null)
            {
                AudioSource.PlayClipAtPoint(seClip, Vector3.zero, 1f);
            }

            // フェードイン
            float timer = 0f;
            while (timer < fadeDuration)
            {
                DamageImg.color = Color.Lerp(clearColor, flashColor, timer / fadeDuration);
                timer += Time.deltaTime;
                yield return null;
            }
            DamageImg.color = flashColor;

            // 赤色を維持
            yield return new WaitForSeconds(stayDuration);

            // フェードアウト
            timer = 0f;
            while (timer < fadeDuration)
            {
                DamageImg.color = Color.Lerp(flashColor, clearColor, timer / fadeDuration);
                timer += Time.deltaTime;
                yield return null;
            }
            DamageImg.color = clearColor;

            yield return new WaitForSeconds(delayBetweenFlashes);
        }

        // フラッシュ後、少し遅れてシーン遷移
        yield return new WaitForSeconds(sceneDelayAfterEffect);

        // シーン遷移（名前が空でなければ）
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }

        isGameOverEffectPlaying = false;
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TextKey : LaserAdventureGame
{
    [SerializeField] private TextMeshProUGUI KeyText;

    [SerializeField] private GameObject objectToDisable;
    [SerializeField] private GameObject objectToDisableFor7;

    [SerializeField] private AudioSource seFor6Key;

    [SerializeField] private Image fadeImage; // 白フェード用Image（Canvas内）

    [SerializeField] private float fadeDuration = 1.0f;      // フェード時間
    [SerializeField] private float delayBeforeFade = 1.0f;   // ボタン押してからフェード開始までの遅延

    private void Start()
    {
        // シーン開始時は透明に設定
        SetFadeAlpha(0f);
    }

    private void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.digit1Key.isPressed)
        {
            KeyText.text = "まずは前のレーザーを\n進みながらよけてみよう！";
        }
        else if (keyboard.digit2Key.isPressed)
        {
            KeyText.text = "炎に当たるとダメージを\n食らうから気を付けよう！";
        }
        else if (keyboard.digit3Key.isPressed)
        {
            KeyText.text = "次は、お宝をとってみよう！";
        }
        else if (keyboard.digit4Key.isPressed)
        {
            KeyText.text = "炎が消えたらコインのところまで来てね！";
        }
        else if (keyboard.digit5Key.wasPressedThisFrame)
        {
            if (objectToDisable != null) objectToDisable.SetActive(false);
            else Debug.LogWarning("5キーで無効化するオブジェクトが設定されていません。");
        }
        else if (keyboard.digit6Key.wasPressedThisFrame)
        {
            KeyText.text = "危ない！前からレーザーが来る！\n体を動かしてよけて！";

            if (seFor6Key != null && seFor6Key.clip != null)
                seFor6Key.PlayOneShot(seFor6Key.clip);
            else
                Debug.LogWarning("6キー用のSEが設定されていません。");
        }
        else if (keyboard.digit7Key.wasPressedThisFrame)
        {
            KeyText.text = "チュートリアルはここまで！\n後ろの円のところに戻ってね！";

            if (objectToDisableFor7 != null) objectToDisableFor7.SetActive(false);
            else Debug.LogWarning("7キーで無効化するオブジェクトが設定されていません。");
        }
        else if (keyboard.digit8Key.isPressed)
        {
            KeyText.text = $"{GetPlayerLives()}回レーザーに当たるとゲームオーバー！";
        }
        else if (keyboard.digit9Key.isPressed)
        {
            KeyText.text = $"制限時間は{limitMin}分、目指せお宝ゲット！";
        }
        else if (keyboard.digit0Key.wasPressedThisFrame)
        {
            KeyText.text = "任務スタート！";
            StartCoroutine(DelayThenFadeAndLoadScene("LaserRoom"));
        }
    }

    private IEnumerator DelayThenFadeAndLoadScene(string sceneName)
    {
        // 1秒遅延
        yield return new WaitForSeconds(delayBeforeFade);

        // 白フェードイン（透明→白）
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));

        // シーン遷移
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        Color startColor = new Color(1f, 1f, 1f, startAlpha);
        Color endColor = new Color(1f, 1f, 1f, endAlpha);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            fadeImage.color = Color.Lerp(startColor, endColor, elapsed / duration);
            yield return null;
        }
        fadeImage.color = endColor;
    }

    private void SetFadeAlpha(float alpha)
    {
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = alpha;
            fadeImage.color = c;
        }
    }
}

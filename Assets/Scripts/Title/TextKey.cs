using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TextKey : LaserAdventureGame
{
    [SerializeField] TextMeshProUGUI KeyText;
    [SerializeField] Transform targetObject;
    [SerializeField] float moveSpeed = 2f;

    [SerializeField] private GameObject objectToDisable;      // 5キーで無効化するオブジェクト
    [SerializeField] private GameObject objectToDisableFor7;  // 7キーで無効化するオブジェクト

    [SerializeField] private AudioSource seFor6Key;           // 6キーで鳴らすSE

    private bool isMoving = false;
    private Vector3 moveDirection = new Vector3(0f, 0f, -1f);

    private void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.digit1Key.isPressed)
        {
            KeyText.text = "まずは目の前のレーザーを\n動いてよけてみよう！";
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
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }
            else
            {
                Debug.LogWarning("5キーで無効化するオブジェクトが設定されていません。");
            }
        }
        else if (keyboard.digit6Key.wasPressedThisFrame)
        {
            KeyText.text = "危ない！前からレーザーが来る！\n体を動かしてよけて！";

            if (seFor6Key != null && seFor6Key.clip != null)
            {
                seFor6Key.PlayOneShot(seFor6Key.clip);
            }
            else
            {
                Debug.LogWarning("6キー用のSEが設定されていません。");
            }
        }
        else if (keyboard.digit7Key.wasPressedThisFrame)
        {
            KeyText.text = "チュートリアルはここまで！\n元の位置に戻ってね！";
            if (objectToDisableFor7 != null)
            {
                objectToDisableFor7.SetActive(false);
            }
            else
            {
                Debug.LogWarning("7キーで無効化するオブジェクトが設定されていません。");
            }
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
            isMoving = true;
            StartCoroutine(DelayAndLoadScene());
        }

        if (isMoving && targetObject != null)
        {
            targetObject.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    System.Collections.IEnumerator DelayAndLoadScene()
    {
        yield return new WaitForSeconds(2f);
        ResetEverything();
        SceneManager.LoadScene("LaserRoom");
    }
}

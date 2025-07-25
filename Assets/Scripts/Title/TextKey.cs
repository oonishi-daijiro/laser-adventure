using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TextKey : LaserAdventureGame
{
    [SerializeField] TextMeshProUGUI KeyText;
    [SerializeField] Transform targetObject;     // 動かすオブジェクト
    [SerializeField] float moveSpeed = 2f;       // Z軸マイナス方向への速度

    private bool isMoving = false;
    private Vector3 moveDirection = new Vector3(0f, 0f, -1f);

    private void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.digit1Key.isPressed)
        {
            KeyText.text = "その場でレーザーをよけよう！";
        }
        else if (keyboard.digit2Key.isPressed)
        {
            KeyText.text = "レーザーが迫ってくるよ！";
        }
        else if (keyboard.digit3Key.isPressed)
        {
            KeyText.text = $"{GetPlayerLives()}回レーザーに当たるとゲームオーバー！";
        }
        else if (keyboard.digit4Key.isPressed)
        {
            KeyText.text = $"制限時間は{limitMin}分、スパイになって目指せお宝ゲット！";
        }
        else if (keyboard.digit5Key.wasPressedThisFrame)
        {
            KeyText.text = "任務スタート！";
            isMoving = true;
            StartCoroutine(DelayAndLoadScene());
        }

        // Z軸に動かす処理
        if (isMoving && targetObject != null)
        {
            targetObject.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    System.Collections.IEnumerator DelayAndLoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LaserRoom");
    }
}

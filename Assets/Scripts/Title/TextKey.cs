using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TextKey : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KeyText;

    private void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard == null) return; // キーボードが接続されていない場合

        if (keyboard.digit1Key.isPressed)
        {
            KeyText.text = "動きながらレーザーをよけよう！";
        }
        else if (keyboard.digit2Key.isPressed)
        {
            KeyText.text = "迫りくるレーザーをよけよう！";
        }
        else if (keyboard.digit3Key.isPressed)
        {
            KeyText.text = "３回レーザーに当たるとゲームオーバー！";
        }
        else if (keyboard.digit4Key.isPressed)
        {
            KeyText.text = "制限時間は１分、スパイになって目指せお宝ゲット！";
        }
        else if (keyboard.digit5Key.isPressed)
        {
            Debug.Log("fuck");
            SceneManager.LoadScene("LaserRoom");
        }
    }
}

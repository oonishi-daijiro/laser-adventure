using UnityEngine;

public class TitleOverlayController : MonoBehaviour
{
    public GameObject titleCanvas;     // タイトル画面用のCanvas（UI全体）

    void Start()
    {
        ShowTitle(true); // 初期状態はタイトル表示
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowTitle(true); // タイトル画面を表示
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowTitle(false); // タイトル画面を非表示（VR映像のみ）
        }
    }

    void ShowTitle(bool show)
    {
        if (titleCanvas != null)
        {
            titleCanvas.SetActive(show);
        }
    }
}

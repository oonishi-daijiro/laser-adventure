using UnityEngine;

public class DisableObjectOnSpace : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("ターゲットオブジェクトが設定されていません。");
            }
        }
    }
}

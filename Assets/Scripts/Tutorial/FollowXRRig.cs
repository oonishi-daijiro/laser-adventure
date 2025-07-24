using UnityEngine;

public class FollowXRRig : MonoBehaviour
{
    [Header("追従対象のカメラ (Main Cameraなど)")]
    public Transform targetCamera;

    [Header("追従させるカプセル")]
    public Transform capsuleToFollow;  // ← カプセルをInspectorで指定

    [Header("Y軸オフセット（カメラからどれだけ下に配置するか）")]
    public float yOffset = -1.0f;

    void Start()
    {
        // Camera自動設定（未設定なら MainCamera を使う）
        if (targetCamera == null && Camera.main != null)
        {
            targetCamera = Camera.main.transform;
        }

        // capsuleToFollow が未設定の場合は警告
        if (capsuleToFollow == null)
        {
            Debug.LogWarning("FollowCameraXZ: capsuleToFollow が設定されていません");
        }
    }

    void Update()
    {
        if (targetCamera == null || capsuleToFollow == null) return;

        Vector3 camPos = targetCamera.position;

        // capsule をカメラのXZに追従、Yはカメラからのオフセット分
        capsuleToFollow.position = new Vector3(camPos.x, camPos.y + yOffset, camPos.z);
    }
}

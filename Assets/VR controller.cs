using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class controller : MonoBehaviour
{
    public XRNode inputSource = XRNode.RightHand;  // コントローラー（右手または左手）
    private InputDevice device;
    private Vector2 inputAxis;                    // コントローラーのスティック入力
    public float moveSpeed = 3.0f;                // キャラクターの移動速度
    public Transform cameraTransform;             // カメラのTransform（プレイヤーの視点）
    public GameObject character;

    private void Start()
    {
        // 入力デバイスを取得]
        device = InputDevices.GetDeviceAtXRNode(inputSource);


    }

    private void Update()
    {
        if (device.isValid)
        {
            // スティック入力を取得
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
            // キャラクターを移動させる
            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
        // コントローラーのスティック入力に基づいて移動方向を計算
        Vector3 moveDirection = new Vector3(inputAxis.x, 0, inputAxis.y);

        // カメラの向きを基準に移動方向を調整
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection.y = 0;  // 垂直方向の移動を無効化（地面に沿った移動）

        // キャラクターを移動
        character.transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}

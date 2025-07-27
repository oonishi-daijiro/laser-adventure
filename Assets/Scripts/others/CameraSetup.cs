using UnityEngine;
using UnityEngine.UI;

public class CameraSetup : MonoBehaviour
{
    public Camera vrCamera;            // VR用カメラ
    public Camera pcCamera;            // PC用カメラ
    public RenderTexture renderTexture; // 作成したRenderTexture
    public RawImage pcRawImage;        // UIのRawImage

    void Start()
    {
        // VRカメラにはターゲットテクスチャを設定しない
        vrCamera.targetTexture = null;

        // PCカメラにRenderTextureを設定
        pcCamera.targetTexture = renderTexture;

        // RawImageのテクスチャにRenderTextureを設定
        pcRawImage.texture = renderTexture;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class LaserHitDetectorWithDamage : MonoBehaviour
{
    [SerializeField] private AudioSource se;
    [SerializeField] private Image damageImg;

    private float fadeDuration = 1.0f;     // 完全に透明になるまでの秒数
    private float fadeElapsed = 0f;        // 経過時間
    private bool isFading = false;         // フェード中かどうか

    void Start()
    {
        if (damageImg != null)
        {
            damageImg.color = Color.clear; // 初期状態は透明
        }
    }

    void Update()
    {
        if (isFading && damageImg != null)
        {
            fadeElapsed += Time.deltaTime;

            // アルファ値を減らしていく（赤 → 透明）
            float alpha = Mathf.Clamp01(1.0f - (fadeElapsed / fadeDuration));
            damageImg.color = new Color(0.7f, 0, 0, alpha);

            if (fadeElapsed >= fadeDuration)
            {
                isFading = false;
                damageImg.color = Color.clear;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            // 効果音の再生
            if (se != null && se.clip != null)
            {
                se.PlayOneShot(se.clip);
            }

            // 赤く表示してフェード開始
            if (damageImg != null)
            {
                damageImg.color = new Color(0.7f, 0, 0, 0.7f);
                fadeElapsed = 0f;
                isFading = true;
            }
        }
    }
}

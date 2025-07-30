using UnityEngine;
using UnityEngine.UI;

public class LaserHitDetectorWithDamage : MonoBehaviour
{
    [SerializeField] private AudioSource se;
    [SerializeField] private AudioClip coinSe;         // Treasure 用の SE（名前はそのままでもOK）
    [SerializeField] private Image damageImg;

    private float fadeDuration = 1.0f;
    private float fadeElapsed = 0f;
    private bool isFading = false;

    void Start()
    {
        if (damageImg != null)
        {
            damageImg.color = Color.clear;
        }
    }

    void Update()
    {
        if (isFading && damageImg != null)
        {
            fadeElapsed += Time.deltaTime;
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
            // レーザーのSE
            if (se != null && se.clip != null)
            {
                se.PlayOneShot(se.clip);
            }

            // ダメージ画像フェード処理
            if (damageImg != null)
            {
                damageImg.color = new Color(0.7f, 0, 0, 0.7f);
                fadeElapsed = 0f;
                isFading = true;
            }
        }
        else if (other.CompareTag("Treasure"))
        {
            // SE を再生
            if (se != null && coinSe != null)
            {
                se.PlayOneShot(coinSe);
            }

            // コイン（Treasure）を削除
            Destroy(other.gameObject);
        }

    }
}

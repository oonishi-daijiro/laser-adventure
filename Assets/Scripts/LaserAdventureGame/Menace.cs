using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menace : LaserAdventureGame, IPlayerCollideAble
{
    [SerializeField] Image DamageImg;

    private float fadeDuration = 1.0f;     // 透明に戻るまでの時間（1秒）
    private float fadeElapsed = 0f;        // 経過時間
    private bool isFading = false;         // フェード中フラグ

    void Start()
    {
        DamageImg.color = Color.clear;
    }

    void Update()
    {
        if (isFading)
        {
            fadeElapsed += Time.deltaTime;

            // アルファ値を1 → 0へ線形に減らす
            float alpha = Mathf.Clamp01(1.0f - (fadeElapsed / fadeDuration));
            DamageImg.color = new Color(0.7f, 0, 0, alpha);

            // 完全に透明になったら停止
            if (fadeElapsed >= fadeDuration)
            {
                isFading = false;
                DamageImg.color = Color.clear;
            }
        }
    }

    public void OnCollideToPlayer()
    {
        DecreasePlayerLives();
        SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.LaserCollision);

        // 赤色で表示し、フェードを開始
        DamageImg.color = new Color(0.7f, 0, 0, 0.7f); // 赤70%、透明度70%
        fadeElapsed = 0f;
        isFading = true;
    }
}



using UnityEngine;

public class Treasure : LaserAdventureGame, IPlayerCollideAble
{
    [SerializeField] LaserAdventureGame.TreasureScores score;

    public void OnCollideToPlayer()
    {
        SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.Cash);
        AddScore(score);
        Destroy(gameObject);
    }
}

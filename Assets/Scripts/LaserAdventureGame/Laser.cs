using UnityEngine;

public class Laser : LaserAdventureGame, IPlayerCollideAble
{
    public void OnCollideToPlayer()
    {
        DecreasePlayerLives();
        SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.LaserCollision);
    }
}

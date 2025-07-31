using UnityEngine;

public class Fire : LaserAdventureGame, IPlayerCollideAble
{
    
    public void OnCollideToPlayer()
    {
        DecreasePlayerLives();
        SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.LaserCollision);
    }
}

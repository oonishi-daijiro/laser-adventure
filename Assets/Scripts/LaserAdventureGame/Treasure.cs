using UnityEngine;

public class Treasure : LaserAdventureGame, IPlayerCollideAble, ISoccerBallColideAble
{
    [SerializeField] LaserAdventureGame.TreasureScores score;
    void onCollide()
    {
        SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.Cash);
        AddScore(score);
        Destroy(gameObject);
    }

    public void OnCollideToPlayer()
    {
        onCollide();
    }

    public void OnCollideToBall()
    {
        onCollide();
    }

}

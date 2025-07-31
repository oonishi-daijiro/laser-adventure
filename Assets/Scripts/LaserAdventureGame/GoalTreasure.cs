using UnityEngine;

public class GoalTreasure : LaserAdventureGame, IPlayerCollideAble
{
    public void OnCollideToPlayer()
    {
        SetGameState(GameState.Completed);
    }
}

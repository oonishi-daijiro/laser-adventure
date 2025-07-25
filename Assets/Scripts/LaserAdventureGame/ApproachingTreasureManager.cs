using System.Collections.Generic;
using UnityEngine;

public class ApproachingTreasureManager : InvokePeriodically
{
    [SerializeField] List<GameObject> treasures = new();
    System.Random rand = new();

    protected override void Invoke()
    {
        if (GetGameState() == GameState.PlayingApproachingPostureLaser)
        {
            var obj = Instantiate(treasures[rand.Next(0, treasures.Count)]);

            if (obj.TryGetComponent<ApproachingFromFront>(out var comp))
            {
                var randomX = rand.Next(-1, 1);
                comp.Initialize(Quaternion.identity, new Vector3(randomX, obj.transform.position.y, 0), 0.01f, "Treasure");
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ApproachingTreasureManager : InvokePeriodically
{
    [SerializeField] List<GameObject> treasures = new();
    readonly System.Random rand = new();

    protected override void Invoke()
    {
        if (GetGameState() == GameState.PlayingApproachingPostureLaser)
        {
            var obj = Instantiate(treasures[rand.Next(0, treasures.Count)]);

            if (obj.TryGetComponent<ApproachingFromFront>(out var comp))
            {
                var randomX = Random.Range(-1.0f, 1.0f);
                var randomY = Random.Range(0, 1f);
                comp.Initialize(Quaternion.identity, new Vector3(randomX, obj.transform.position.y + randomY, 0), 0.01f, "Treasure");
            }
        }
    }
}

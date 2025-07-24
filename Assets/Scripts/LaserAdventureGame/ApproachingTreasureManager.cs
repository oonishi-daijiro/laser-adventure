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
            var comp = obj.GetComponent<ApproachingFromFront>();
            if (comp != null)
            {
                Debug.Log("Instantiate treasure");
                var randomX = rand.Next(-1, 1);
                comp.Initialize(Quaternion.identity, new Vector3(randomX, 0, 0), 0.01f);
            }
            else
            {
                Debug.Log("cannnot Instantiate ");
            }

        }
    }
}

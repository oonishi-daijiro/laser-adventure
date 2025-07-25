using UnityEngine;

public class EmitHMDPos : LaserAdventureGame
{
    void Update()
    {
        SetPlayerPos(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}

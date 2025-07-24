using TMPro;
using UnityEngine;

public class GameDebugger : LaserAdventureGame
{
    [SerializeField] TextMeshProUGUI debugOutTxt;

    void Update()
    {
        debugOutTxt.text = GetDebugGameState();
    }
}

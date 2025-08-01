using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : LaserAdventureGame
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public TextMeshProUGUI scoreTxt;
    void Start()
    {
        scoreTxt.text = $"ハイスコア:{GetHighestScore().ToString()}";
    }
}

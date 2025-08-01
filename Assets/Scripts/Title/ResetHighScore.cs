using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetHighScore : LaserAdventureGame
{
    [SerializeField] public TextMeshProUGUI scoreTxt;
    public void OnClickButton()
    {
        ResetHighestScore();
        scoreTxt.text = $"ハイスコア:{GetHighestScore().ToString()}";
    }

}

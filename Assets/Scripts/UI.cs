using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _hpText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _levelText;

    public void UpdateLevelAndScore()
    {
        _levelText.text = $"Level {Stats.Level}";
        _scoreText.text = "Score: " + Stats.Score.ToString("D4");
    }
    public void UpdateHealth(int hp)
    {
        _hpText.text = $"HP: {hp}";
    }
}

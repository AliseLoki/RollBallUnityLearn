using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private const string DefaultScoreText = "Score:";

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _winText;

    public void UpdateText(int score)
    {
        _scoreText.text = DefaultScoreText + score.ToString();
    }
}

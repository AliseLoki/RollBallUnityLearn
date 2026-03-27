using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private const string DefaultScoreText = "Score:";
    private const string LoseText = "YOU LOOSE!!!";

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _winText;

    public void UpdateText(int score)
    {
        _scoreText.text = DefaultScoreText + score.ToString();
    }

    public void ShowWinText()
    {
        _winText.gameObject.SetActive(true);
    }

    internal void ShowLoseText()
    {
        _winText.text = LoseText;
        _winText.gameObject.SetActive(true);
    }
}

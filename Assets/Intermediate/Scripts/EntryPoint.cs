using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private const int WinScore = 5;
    private int _score;

    [SerializeField] private PlayerController _player;
    [SerializeField] private UIController _ui;
    [SerializeField] private CameraController _camera;
    [SerializeField] private EnemyController _enemy;

    private void OnEnable()
    {
        _player.CollectablePicked += OnCollectablePicked;
        _player.PlayerCatched += OnPlayerHasBeenCatched;
    }

    private void OnDisable()
    {
        _player.CollectablePicked -= OnCollectablePicked;
        _player.PlayerCatched -= OnPlayerHasBeenCatched;
    }

    private void Awake()
    {
        _camera.Init(_player.transform);
        _enemy.Init(_player.transform);
    }

    private void OnPlayerHasBeenCatched()
    {
        _ui.ShowLoseText();
        StopGame();
    }

    private void OnCollectablePicked()
    {
        AddScore();
        _ui.UpdateText(_score);
        CheckIfEnoughScoreForWin(_score);
    }

    private void AddScore()
    {
        _score++;
    }

    private void CheckIfEnoughScoreForWin(int score)
    {
        if (score >= WinScore)
        {
            _ui.ShowWinText();
            StopGame();
        }
    }

    private static void StopGame()
    {
        Time.timeScale = 0;
    }
}

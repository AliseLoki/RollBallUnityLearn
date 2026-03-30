using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private const int WinScore = 5;
    private int _score;

    [SerializeField] private PlayerController _player;  // ссылки на все основные объекты в игре
    [SerializeField] private UIController _ui;
    [SerializeField] private CameraController _camera;
    [SerializeField] private EnemyController _enemy;

    private void OnEnable()
    {
        _player.CollectablePicked += OnCollectablePicked;  // подписка на основные события в игре  -  сбор коллектэблов и если враг поймал
        _player.PlayerCatched += OnPlayerHasBeenCatched;
    }

    private void OnDisable()
    {
        _player.CollectablePicked -= OnCollectablePicked;
        _player.PlayerCatched -= OnPlayerHasBeenCatched;
    }

    private void Awake()
    {
        _camera.Init(_player.transform);  // инициализация всех приватных переменных в других скриптах
        _enemy.Init(_player.transform);
    }

    private void OnPlayerHasBeenCatched() // вызов всех методов которые должны сработать если враг поймал игрока
    {
        _ui.ShowLoseText();
        StopGame();
    }

    private void OnCollectablePicked() // вызов всех методов которые должны сработать если игрок собрал коллектэбл
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

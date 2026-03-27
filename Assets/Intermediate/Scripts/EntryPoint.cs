using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private const int WinScore = 5;

    [SerializeField] private GameObject _level;
    [SerializeField] private PlayerController _player;
    [SerializeField] private UIController _ui;
    [SerializeField] private CollectableController _collectableController;
    [SerializeField] private Transform _collectablesParent;
    [SerializeField] private CameraController _camera;
    [SerializeField] private EnemyController _enemy;

    private void OnEnable()
    {
        _player.ScoreHasChanged += OnScoreHasChanged;
        _player.PlayerCatched += OnPlayerHasBeenCatched;
    }

    private void OnDisable()
    {
        _player.ScoreHasChanged -= OnScoreHasChanged;
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

    private void OnScoreHasChanged(int score)
    {
        _ui.UpdateText(score);
        CheckIfEnoughScoreForWin(score);
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

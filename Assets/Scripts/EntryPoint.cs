using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _level;
    [SerializeField] private PlayerController _player;
    [SerializeField] private UIController _ui;
    [SerializeField] private CollectableController _collectableController;
    [SerializeField] private Transform _collectablesParent;
    [SerializeField] private CameraController _camera;

    private void OnEnable()
    {
        _player.ScoreHasChanged += OnScoreHasChanged;
    }


    private void OnDisable()
    {
        _player.ScoreHasChanged -= OnScoreHasChanged;
    }

    private void Awake()
    {
        _camera.Init(_player.transform);
    }

    private void OnScoreHasChanged(int score)
    {
        _ui.UpdateText(score);
    }
}

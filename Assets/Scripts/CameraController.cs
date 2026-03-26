using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _offset;

    public void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _offset = transform.position - _playerTransform.position;
    }

    private void LateUpdate()
    {
        transform.position = _offset + _playerTransform.position;
    }
}

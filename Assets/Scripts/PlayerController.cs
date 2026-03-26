using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody _rb;

    private int _score;

    private Vector3 _inputVector;

    public event Action<int> ScoreHasChanged;

    private void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        _inputVector = new Vector3(inputVector.x, 0, inputVector.y);
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_inputVector * _moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CollectableController collectable))
        {
            other.gameObject.SetActive(false);
            _score++;
            ScoreHasChanged?.Invoke(_score);
        }
    }
}

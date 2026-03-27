using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody _rb;

    private Vector3 _inputVector;

    public event Action CollectablePicked;
    public event Action PlayerCatched;

    private void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        _inputVector = new Vector3(inputVector.x, 0, inputVector.y);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rb.AddForce(_inputVector * _moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckIfCollectable(other);
        CheckIfEnemy(other);
    }

    private void CheckIfEnemy(Collider other)
    {
        if (other.TryGetComponent(out EnemyController enemy))
        {
            PlayerCatched?.Invoke();
        }
    }

    private void CheckIfCollectable(Collider other)
    {
        if (other.TryGetComponent(out CollectableController collectable))
        {
            other.gameObject.SetActive(false);
            CollectablePicked?.Invoke();
        }
    }
}

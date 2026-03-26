using UnityEngine;

public class CollectableController : MonoBehaviour
{
    private Vector3 _rotationVector = new(15, 40, 45);

    private void Update()
    {
        Rotate(_rotationVector);
    }

    private void Rotate(Vector3 rotatationVector)
    {
        transform.Rotate(rotatationVector * Time.deltaTime);
    }
}

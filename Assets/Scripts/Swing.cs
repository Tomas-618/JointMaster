using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField, Min(0)] private float _pushingForce;

    [SerializeField] private Rigidbody _rigidbody;

    private void Update() =>
        Push();

    private void Push()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddRelativeForce(Vector3.forward * _pushingForce);
    }
}

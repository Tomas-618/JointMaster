using System;
using System.Threading.Tasks;
using UnityEngine;
using Pools.Interfaces;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField, Min(0)] private int _delay;

    [SerializeField] private MeshFilter _meshFilter;

    private IPoolReleaser<Projectile> _pool;
    private GameObject _gameObject;
    private Transform _transform;
    private Rigidbody _rigidbody;
    private bool _isCollided;

    private async void OnCollisionEnter(Collision collision)
    {
        const int MillisecondsPerSecond = 1000;

        if (_isCollided)
            return;

        if (collision.collider.GetComponent<Obstacle>() == null)
            return;

        _isCollided = true;

        await Task.Delay(_delay * MillisecondsPerSecond);

        if (_gameObject == null)
            return;

        _pool.Release(this);
    }

    public void Init(IPoolReleaser<Projectile> pool)
    {
        _gameObject = gameObject;
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _pool = pool ?? throw new ArgumentNullException(nameof(pool));
    }

    public void SetMesh(Mesh mesh) =>
        _meshFilter.sharedMesh = mesh != null ? mesh : throw new ArgumentNullException(nameof(mesh));

    public void SetPosition(Vector3 position) =>
        _transform.position = position;

    public void EnableObject() =>
        _gameObject.SetActive(true);

    public void DisableObject()
    {
        _isCollided = false;
        _rigidbody.velocity = Vector3.zero;
        _gameObject.SetActive(false);
    }

    public void Destroy() =>
        Destroy(_gameObject);
}

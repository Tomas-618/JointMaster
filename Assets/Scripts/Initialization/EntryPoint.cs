using UnityEngine;
using Factories;
using Pools;

public class EntryPoint : MonoBehaviour
{
    [SerializeField, Min(0)] private int _projectilesPoolCapacity;
    [SerializeField, Min(0)] private int _projectilesPoolMaxSize;

    [SerializeField] private Mesh[] _projectileMeshes;
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Transform _projectilesParent;
    [SerializeField] private Catapult _catapult;

    private void Awake()
    {
        ProjectileFactory projectileFactory = new ProjectileFactory(_projectileMeshes, _prefab, _projectilesParent);

        ProjectilePool projectilePool = new ProjectilePool(projectileFactory, _projectilesParent,
            _projectilesPoolCapacity, _projectilesPoolMaxSize);

        _catapult.Init(projectilePool);
    }
}

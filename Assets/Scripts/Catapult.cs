using UnityEngine;
using Pools;
using System;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _joint;

    private ProjectilePool _projectilePool;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _projectilePool.Get();
    }

    public void Init(ProjectilePool projectilePool) =>
        _projectilePool = projectilePool ?? throw new ArgumentNullException(nameof(projectilePool));

    public void SetAnchorPosition(Vector3 position) =>
        _joint.anchor = position;
}

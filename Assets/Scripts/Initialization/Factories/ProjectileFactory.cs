using System;
using UnityEngine;
using Pools.Interfaces;

namespace Factories
{
    public class ProjectileFactory
    {
        private readonly Mesh[] _meshes;
        private readonly Projectile _prefab;

        public ProjectileFactory(Mesh[] meshes, Projectile prefab)
        {
            _meshes = meshes ?? throw new ArgumentNullException(nameof(meshes));
            _prefab = prefab != null ? prefab : throw new ArgumentNullException(nameof(prefab));
        }

        public Projectile Create(IPoolReleaser<Projectile> pool, Transform parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            int randomMeshIndex = UnityEngine.Random.Range(0, _meshes.Length);

            Projectile projectile = UnityEngine.Object.Instantiate(_prefab, parent);

            Mesh mesh = _meshes[randomMeshIndex];

            projectile.Init(pool);
            projectile.SetMesh(mesh);

            return projectile;
        }
    }
}

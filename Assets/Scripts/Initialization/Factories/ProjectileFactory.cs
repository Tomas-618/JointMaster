using UnityEngine;
using Pools.Interfaces;

namespace Factories
{
    public class ProjectileFactory
    {
        private readonly Mesh[] _meshes;
        private readonly Projectile _prefab;
        private readonly Transform _parent;

        public ProjectileFactory(Mesh[] meshes, Projectile prefab, Transform parent)
        {
            _meshes = meshes ?? throw new System.ArgumentNullException(nameof(meshes));
            _prefab = prefab != null ? prefab : throw new System.ArgumentNullException(nameof(prefab));
            _parent = parent != null ? parent : throw new System.ArgumentNullException(nameof(parent));
        }

        public Projectile Create(IPoolReleaser<Projectile> pool)
        {
            int randomMeshIndex = Random.Range(0, _meshes.Length);

            Projectile projectile = Object.Instantiate(_prefab, _parent);

            Mesh mesh = _meshes[randomMeshIndex];

            projectile.Init(pool);
            projectile.SetMesh(mesh);

            return projectile;
        }
    }
}

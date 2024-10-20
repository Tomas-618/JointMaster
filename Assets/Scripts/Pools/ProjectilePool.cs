using System;
using UnityEngine;
using UnityEngine.Pool;
using Factories;
using Pools.Interfaces;

namespace Pools
{
    public class ProjectilePool : IPoolReleaser<Projectile>
    {
        private readonly ObjectPool<Projectile> _pool;
        private readonly ProjectileFactory _factory;

        public ProjectilePool(ProjectileFactory factory, Transform parent, int capacity, int maxSize)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(capacity.ToString());

            if (maxSize <= 0)
                throw new ArgumentOutOfRangeException(maxSize.ToString());

            _factory = factory ?? throw new ArgumentNullException(nameof(factory));

            _pool = new ObjectPool<Projectile>(
                () => _factory.Create(this, parent),
                projectile => { },
                projectile => projectile.DisableObject(),
                projectile => projectile.Destroy(),
                true,
                capacity,
                maxSize);
        }

        public Projectile Get(Vector3 spawnPosition)
        {
            Projectile projectile = _pool.Get();
            
            projectile.SetPosition(spawnPosition);
            projectile.EnableObject();

            return projectile;
        }

        public void Release(Projectile projectile) =>
            _pool.Release(projectile);
    }
}

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
        private readonly Transform _parent;

        public ProjectilePool(ProjectileFactory factory, Transform parent, int capacity, int maxSize)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(capacity.ToString());

            if (maxSize <= 0)
                throw new ArgumentOutOfRangeException(maxSize.ToString());

            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _parent = parent;

            _pool = new ObjectPool<Projectile>(
                () => _factory.Create(this),
                OnGet,
                projectile => projectile.DisableObject(),
                projectile => projectile.Destroy(),
                true,
                capacity,
                maxSize);
        }

        public Projectile Get() =>
            _pool.Get();

        public void Release(Projectile projectile) =>
            _pool.Release(projectile);

        private void OnGet(Projectile projectile)
        {
            projectile.EnableObject();
            projectile.SetPosition(_parent.position);
        }
    }
}

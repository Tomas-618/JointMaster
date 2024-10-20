using System;
using UnityEngine;
using Pools;
using Utils.BasicStateMachine;

namespace States.CatapultStates
{
    public class CatapultIdleState : State
    {
        private readonly ProjectilePool _projectilePool;
        private readonly Transform _projectilesSpawnPoint;

        public CatapultIdleState(ProjectilePool projectilePool, Transform projectilesSpawnPoint)
        {
            _projectilePool = projectilePool ?? throw new ArgumentNullException(nameof(projectilePool));
            _projectilesSpawnPoint = projectilesSpawnPoint != null ?
                projectilesSpawnPoint : throw new ArgumentNullException(nameof(projectilesSpawnPoint));
        }

        protected override void OnEnter() =>
            _projectilePool.Get(_projectilesSpawnPoint.position);
    }
}

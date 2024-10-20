using UnityEngine;
using Factories;
using Pools;
using Configs;
using Utils.BasicStateMachine;
using Services;

public class EntryPoint : MonoBehaviour
{
    [SerializeField, Min(0)] private int _projectilesPoolCapacity;
    [SerializeField, Min(0)] private int _projectilesPoolMaxSize;

    [SerializeField] private Mesh[] _projectileMeshes;
    [SerializeField] private Swing _swing;
    [SerializeField] private Projectile _prefab;
    [SerializeField] private Catapult _catapult;
    [SerializeField] private CatapultLifeCycle _catapultLifeCycle;
    [SerializeField] private CatapultValuesConfig _catapultValuesConfig;
    [SerializeField] private Transform _projectilesParent;

    private UpdateService _updateService;

    private void Awake()
    {
        _updateService = new UpdateService();

        _swing.Init(_updateService);

        ProjectileFactory projectileFactory = new ProjectileFactory(_projectileMeshes, _prefab);

        ProjectilePool projectilePool = new ProjectilePool(projectileFactory, _projectilesParent,
            _projectilesPoolCapacity, _projectilesPoolMaxSize);

        StateMachine catapultStateMachine = new CatapultStateMachineFactory(
            projectilePool, _catapult, _catapultValuesConfig).Create();

        _catapultLifeCycle.Init(catapultStateMachine, _updateService);
    }

    private void Update() =>
        _updateService.OnUpdate();
}

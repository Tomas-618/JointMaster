using System;
using Configs;
using Pools;
using States.CatapultStates;
using Transitions.CatapultTransitions;
using Utils.BasicStateMachine;

namespace Factories
{
    public class CatapultStateMachineFactory
    {
        private readonly ProjectilePool _projectilePool;
        private readonly Catapult _catapult;
        private readonly CatapultValuesConfig _valuesConfig;

        public CatapultStateMachineFactory(ProjectilePool projectilePool, Catapult catapult, CatapultValuesConfig valuesConfig)
        {
            _projectilePool = projectilePool ?? throw new ArgumentNullException(nameof(projectilePool));
            _catapult = catapult != null ? catapult : throw new ArgumentNullException(nameof(catapult));
            _valuesConfig = valuesConfig != null ? valuesConfig : throw new ArgumentNullException(nameof(valuesConfig));
        }

        public StateMachine Create()
        {
            CatapultActivatedState activatedState = new CatapultActivatedState();
            CatapultIdleState idleState = new CatapultIdleState(_projectilePool, _catapult.ProjectilesSpawnTarget);
            CatapultToActivedState toActivedState = new CatapultToActivedState(_catapult, _valuesConfig);
            CatapultToIdleState toIdleState = new CatapultToIdleState(_catapult, _valuesConfig);

            CatapultArrivalCheckingTransition idleTransition = new CatapultArrivalCheckingTransition(idleState, _catapult);
            CatapultArrivalCheckingTransition activatedTransition = new CatapultArrivalCheckingTransition(activatedState,
                _catapult);
            CatapultToActivatedTransition toActivatedTransition = new CatapultToActivatedTransition(toActivedState);
            CatapultToIdleTransition toIdleTransition = new CatapultToIdleTransition(toIdleState);

            activatedState.AddTransition(toIdleTransition);
            idleState.AddTransition(toActivatedTransition);

            toActivedState.AddTransition(activatedTransition);
            toIdleState.AddTransition(idleTransition);

            return new StateMachine(activatedState);
        }
    }
}

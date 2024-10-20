using System;
using Configs;
using Utils.BasicStateMachine;

namespace States.CatapultStates
{
    public class CatapultToIdleState : State
    {
        private readonly Catapult _catapult;
        private readonly CatapultValuesConfig _config;

        public CatapultToIdleState(Catapult catapult, CatapultValuesConfig config)
        {
            _catapult = catapult != null ? catapult : throw new ArgumentNullException(nameof(catapult));
            _config = config != null ? config : throw new ArgumentNullException(nameof(config));
        }

        protected override void OnEnter()
        {
            _catapult.SetTargetValue(_config.OnIdleRotationX);
            _catapult.SetAnchorPosition(_config.AnchorOnIdlePosition);
        }
    }
}

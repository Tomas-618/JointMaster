using System;
using Configs;
using Utils.BasicStateMachine;

namespace States.CatapultStates
{
    public class CatapultToActivedState : State
    {
        private readonly Catapult _catapult;
        private readonly CatapultValuesConfig _config;

        public CatapultToActivedState(Catapult catapult, CatapultValuesConfig config)
        {
            _catapult = catapult != null ? catapult : throw new ArgumentNullException(nameof(catapult));
            _config = config != null ? config : throw new ArgumentNullException(nameof(config));
        }

        protected override void OnEnter()
        {
            _catapult.SetTargetValue(_config.OnActivatedRotationX);
            _catapult.SetAnchorPosition(_config.AnchorOnActivatedPosition);
        }
    }
}

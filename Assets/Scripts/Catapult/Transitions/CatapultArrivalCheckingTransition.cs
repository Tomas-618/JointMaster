using System;
using Utils.BasicStateMachine;

namespace Transitions.CatapultTransitions
{
    public class CatapultArrivalCheckingTransition : Transition
    {
        private readonly Catapult _catapult;

        public CatapultArrivalCheckingTransition(State state, Catapult catapult) : base(state) =>
            _catapult = catapult != null ? catapult : throw new ArgumentNullException(nameof(catapult));

        public override void Update()
        {
            if (_catapult.IsNearestToTarget && _catapult.IsMoving == false)
                Open();
        }
    }
}

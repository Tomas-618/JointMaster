using UnityEngine;
using Utils.BasicStateMachine;

namespace Transitions.CatapultTransitions
{
    public class CatapultToActivatedTransition : Transition
    {
        public CatapultToActivatedTransition(State nextState) : base(nextState) { }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Open();
        }
    }
}

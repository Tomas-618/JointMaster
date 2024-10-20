using UnityEngine;
using Utils.BasicStateMachine;

namespace Transitions.CatapultTransitions
{
    public class CatapultToIdleTransition : Transition
    {
        public CatapultToIdleTransition(State nextState) : base(nextState) { }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(1))
                Open();
        }
    }
}

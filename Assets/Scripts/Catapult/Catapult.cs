using Utils;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    private const float RotationVelocityThreshold = 0.01f;

    [SerializeField] private SpringJoint _joint;
    [SerializeField] private Rigidbody _spoon;
    
    private int _targetValue;

    [field: SerializeField] public Transform ProjectilesSpawnTarget { get; private set; }

    public bool IsNearestToTarget => (int)(MathUtils.MaxAngle - _spoon.rotation.eulerAngles.x) == _targetValue;

    public bool IsMoving => Mathf.Abs(_spoon.angularVelocity.x) > RotationVelocityThreshold;

    public void SetAnchorPosition(Vector3 position) =>
        _joint.anchor = position;

    public void SetTargetValue(int target) =>
        _targetValue = target;
}

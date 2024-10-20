using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "CatapultValuesConfig", menuName = "Configs/CatapultValuesConfig", order = 51)]
    public class CatapultValuesConfig : ScriptableObject
    {
        [SerializeField] private Vector3 _anchorOnIdlePosition;
        [SerializeField] private Vector3 _anchorOnActivatedPosition;
        [SerializeField] private int _onIdleRotationX;
        [SerializeField] private int _onActivatedRotationX;

        public Vector3 AnchorOnIdlePosition => _anchorOnIdlePosition;

        public Vector3 AnchorOnActivatedPosition => _anchorOnActivatedPosition;

        public int OnIdleRotationX => _onIdleRotationX;

        public int OnActivatedRotationX => _onActivatedRotationX;

        private void Reset()
        {
            _anchorOnIdlePosition = new Vector3(0f, 2.9f, 3.3f);
            _anchorOnActivatedPosition = new Vector3(0f, 0.6f, 5.61f);
            _onIdleRotationX = 77;
            _onActivatedRotationX = 62;
        }
    }
}

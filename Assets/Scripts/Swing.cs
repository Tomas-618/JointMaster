using System;
using UnityEngine;
using Services;

public class Swing : MonoBehaviour
{
    [SerializeField, Min(0)] private float _pushingForce;

    [SerializeField] private Rigidbody _rigidbody;

    private UpdateService _updateService;

    private void OnEnable() =>
        AddListenerOnUpdateServiceEvents();

    private void OnDisable() =>
        RemoveListenerOnUpdateServiceEvents();

    public void Init(UpdateService updateService)
    {
        _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));

        RemoveListenerOnUpdateServiceEvents();
        AddListenerOnUpdateServiceEvents();
    }

    private void OnUpdate() =>
        Push();

    private void Push()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddRelativeForce(Vector3.forward * _pushingForce);
    }

    private void AddListenerOnUpdateServiceEvents()
    {
        if (_updateService == null)
            return;

        _updateService.Updated += OnUpdate;
    }

    private void RemoveListenerOnUpdateServiceEvents()
    {
        if (_updateService == null)
            return;

        _updateService.Updated -= OnUpdate;
    }
}

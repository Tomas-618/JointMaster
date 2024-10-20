using System;
using UnityEngine;
using Utils.BasicStateMachine;
using Services;

public class CatapultLifeCycle : MonoBehaviour
{
    private StateMachine _stateMachine;
    private UpdateService _updateService;

    private void OnEnable() =>
        AddListenerOnUpdateServiceEvents();

    private void OnDisable() =>
        RemoveListenerOnUpdateServiceEvents();

    public void Init(StateMachine stateMachine, UpdateService updateService)
    {
        _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));
        _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));

        RemoveListenerOnUpdateServiceEvents();
        AddListenerOnUpdateServiceEvents();
    }

    private void OnUpdated() =>
        _stateMachine.Update();

    private void AddListenerOnUpdateServiceEvents()
    {
        if (_updateService == null)
            return;

        _updateService.Updated += OnUpdated;
    }

    private void RemoveListenerOnUpdateServiceEvents()
    {
        if (_updateService == null)
            return;

        _updateService.Updated -= OnUpdated;
    }
}

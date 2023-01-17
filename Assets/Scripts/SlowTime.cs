using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    private bool _isSlowTime;
    private float _secs;
    private float _countdownTime;

    private void Start()
    {
        _isSlowTime = false;
        _secs = 2.5f; // 5 sec
        _countdownTime = _secs;
    }

    private void Update()
    {
        if (_isSlowTime)
            Countdown();
    }

    public void DoSlowTime()
    {
        _isSlowTime = true;
        Time.timeScale = 0.25f;
    }

    private void ResetTimeSpeed()
    {
        _isSlowTime = false;
        _countdownTime = _secs;
        Time.timeScale = 1;
    }

    private void Countdown()
    {
        _countdownTime -= Time.fixedDeltaTime;

        if (_countdownTime <= 0)
            ResetTimeSpeed();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class GameLoading : MonoBehaviour {

    public NetworkInitializer _networkInitializer;
    public Image _progressBar;
    private float _progressMaxGauge;
    private float _progressFillGauge = 1f;

    void Update() {
        AddProgessBar();
    }

    public bool IsMax() {
        return _progressBar.fillAmount < _progressMaxGauge ? true : false;
    }

    public bool IsFilled() { return _progressBar.fillAmount >= _progressFillGauge; }
    public void SetProgessGauge(float _gauge) {
        _progressMaxGauge = _gauge;
    }

    private void AddProgessBar() {
        _progressMaxGauge = _networkInitializer.GetLoadingGauge();

        if (IsMax())
            _progressBar.fillAmount += 0.01f;
    }
}

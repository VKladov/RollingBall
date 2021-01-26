using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private CoinsReceiver _player;
    [SerializeField] private Text _coinCountView;

    private void OnEnable()
    {
        _player.CoinsChanged += OnCoinCountChanged;
    }

    private void OnDisable()
    {
        _player.CoinsChanged -= OnCoinCountChanged;
    }

    private void OnCoinCountChanged(int count)
    {
        _coinCountView.text = count + "";
    }
}

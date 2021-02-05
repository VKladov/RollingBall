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
        _player.CoinsChanged += OnCoinsChanged;
    }

    private void OnDisable()
    {
        _player.CoinsChanged -= OnCoinsChanged;
    }

    private void OnCoinsChanged(int count)
    {
        _coinCountView.text = count.ToString();
    }
}

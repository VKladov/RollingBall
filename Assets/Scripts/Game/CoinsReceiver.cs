using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinsReceiver : MonoBehaviour
{
    public event UnityAction<int> CoinsChanged;

    private int _coins = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.Deactivate();
            _coins += 1;
            CoinsChanged?.Invoke(_coins);
        }
    }
}

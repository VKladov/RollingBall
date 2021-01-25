using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    public UnityAction<Obstacle> Deactivated;

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Deactivated?.Invoke(this);
        gameObject.SetActive(false);
    }
}

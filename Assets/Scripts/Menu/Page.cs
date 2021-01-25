using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Page : MonoBehaviour
{
    [SerializeField] private Button _backButton;

    private Animator _animator;

    public UnityAction BackPressed;

    public void Open()
    {
        _animator.SetTrigger("open");
    }

    public void Close()
    {
        _animator.SetTrigger("close");
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackPressed);
    }

    protected virtual void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackPressed);
    }

    private void OnBackPressed()
    {
        BackPressed?.Invoke();
    }
}

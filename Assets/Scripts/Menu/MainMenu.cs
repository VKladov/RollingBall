using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : Page
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _authorsButton;

    public UnityAction PlayPressed;
    public UnityAction AuthorsPressed;

    protected override void OnEnable()
    {
        base.OnEnable();

        _playButton.onClick.AddListener(OnPlayPressed);
        _authorsButton.onClick.AddListener(OnAuthorsPressed);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _playButton.onClick.RemoveListener(OnPlayPressed);
        _authorsButton.onClick.RemoveListener(OnAuthorsPressed);
    }

    private void OnPlayPressed() => PlayPressed?.Invoke();

    private void OnAuthorsPressed() => AuthorsPressed?.Invoke();
}

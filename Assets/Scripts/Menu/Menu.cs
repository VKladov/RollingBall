using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Page _authorsPanel;

    private void OnEnable()
    {
        _mainMenu.BackPressed += Exit;
        _mainMenu.AuthorsPressed += GoToAuthors;
        _mainMenu.PlayPressed += StartGame;
        _authorsPanel.BackPressed += GoToMain;
    }

    private void OnDisable()
    {
        _mainMenu.BackPressed -= Exit;
        _mainMenu.AuthorsPressed -= GoToAuthors;
        _mainMenu.PlayPressed -= StartGame;
        _authorsPanel.BackPressed -= GoToMain;
    }

    private void GoToMain()
    {
        _authorsPanel.Close();
        _mainMenu.Open();
    }

    private void GoToAuthors()
    {
        _authorsPanel.Open();
        _mainMenu.Close();
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}

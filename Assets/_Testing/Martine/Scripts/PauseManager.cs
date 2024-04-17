using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject menu;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        playerInputActions.Player.Escape.started += ctx => TogglePause();
    }

    private void OnDestroy()
    {
      //  playerInputActions.Player.Escape.started -= TogglePause;
    }

    public void resume()
    {
        SetPaused(false);
    }

    public void exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void TogglePause()
    {
        SetPaused(!isPaused);
    }

    private void SetPaused(bool paused)
    {
        isPaused = paused;
        menu.SetActive(paused);
        SetTimeScale();
    }

    private void SetTimeScale()
    {
        Time.timeScale = isPaused ? 0 : 1;
    }
}
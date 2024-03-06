using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;

    [Header("Player Scripts to Deactivate on Pause")]
    // [SerializeField] private Player _player;
    // [SerializeField] private PlayerAttack _playerAttack;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;

    private bool isPaused;

    private void Start(){
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
    }

    private void Update(){
        if (InputManager.instance.MenuOpenCloseInput){
            if (!isPaused){
                Pause();
            } else {
                Unpause();
            }
        }
    }

    #region Pause/Unpause functions

    public void Pause(){
        isPaused = true;
        Time.timeScale = 0f;

        // _player.enable = false;
        // _playerAttack.enable = false;

        OpenMainMenu();
    }

    public void Unpause(){
        isPaused = false;
        Time.timeScale = 1f;

        // _player.enable = true;
        // _playerAttack.enable = true;

        CloseAllMenus();
    }

    #endregion

    #region Canvas Activations/Deactivations

    private void OpenMainMenu(){
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void OpenSettingsMenuHandle(){
        _settingsMenuCanvasGO.SetActive(true);
        _mainMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    private void CloseAllMenus(){
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion

    #region Main Menu Button Actions

    public void OnSettingsPress(){
        OpenSettingsMenuHandle();
    }

    public void OnResumePress(){
        Unpause();
    }

    #endregion

    #region Settings Menu Button Actions

    public void OnSettingsBackPress(){
        OpenMainMenu();
    }

    #endregion
}

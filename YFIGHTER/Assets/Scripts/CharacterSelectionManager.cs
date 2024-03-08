using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject[] characters;
    public Toggle[] toggles;
    public int selectedCharacter = 0;
    public bool isCharacterSelected = false;
    public int onCharacter = 0;
    public string toggleName;

    public Button startButton;


    [Header("First Selected Options")]
    [SerializeField] private GameObject _characterSelectionFirst;

    private void Start(){
        characters[selectedCharacter].SetActive(true);
        EventSystem.current.SetSelectedGameObject(_characterSelectionFirst);

        startButton.interactable = false;
    }

    void Update(){
        if (isCharacterSelected){
            startButton.interactable = true;
        } else {
            startButton.interactable = false;
        }
    }

    public void OnHoverToggle(){
        if (!isCharacterSelected){
            toggleName = EventSystem.current.currentSelectedGameObject.name;
            switch (toggleName){
            case "SelectionCharacterToggle1":
                DisplayCharacter(0);
                break;

            case "SelectionCharacterToggle2":
                DisplayCharacter(1);
                break;

            case "SelectionCharacterToggle3":
                DisplayCharacter(2);
                break;

            default:
                Debug.Log("Error in selection");
                break;
            }
        }
    }

    private void DisplayCharacter(int indexCharacter) {
        foreach (var character in characters){
            character.SetActive(false);
        }
        characters[indexCharacter].SetActive(true);
    }

    public void StartGame(){
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ToggleClick(){
        for (int i = 0; i < toggles.Length; i++){
            if (toggles[i].isOn){
                DisplayCharacter(i);
                selectedCharacter = i;
            }
        }

        if(!isCharacterSelected){
            isCharacterSelected = true;
        } else {
            isCharacterSelected = false;
        }
    }

}

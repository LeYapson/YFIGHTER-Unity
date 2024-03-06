using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;
    public int onCharacter = 0;

    public string buttonName;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _characterSelectionFirst;

    private void Start(){
        characters[selectedCharacter].SetActive(true);
        EventSystem.current.SetSelectedGameObject(_characterSelectionFirst);
    }

    public void OnHoverCharacter(){
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName){
        case "SelectionCharacterButton1":
            onCharacter = 0;
            DisplayHoveredCharacter();
            break;

        case "SelectionCharacterButton2":
            onCharacter = 1;
            DisplayHoveredCharacter();
            break;

        case "SelectionCharacterButton3":
            onCharacter = 2;
            DisplayHoveredCharacter();
            break;

        default:
            Debug.Log("Error in selection");
            break;
        }
    }

    private void DisplayHoveredCharacter(){
        foreach (var character in characters){
                character.SetActive(false);
        }
        characters[onCharacter].SetActive(true);
        
        Debug.Log("Selected character : " + onCharacter);
    }

    public void StartGame(){
        PlayerPrefs.SetInt("selectedCharacter", onCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}

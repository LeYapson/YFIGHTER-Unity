using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelectionManager : MonoBehaviour
{
    [Header("Map Parameters")]
    [SerializeField] private int _selectedMap = 0;
    [SerializeField] private bool _isMapSelected = false;
    public GameObject[] Maps;

    [Header("Map Selection UI/Images")]
    [SerializeField] private int _navPos = 0;
    public Image navigator;
    public Image selectedMap;

    [Header("Start Button Selection UI/Images")]
    public Button startButton;
    public Image startGameNavigator;
	public RectTransform[] slots;

    private void Start(){
        // charactersPlayer1[_selectedMap].SetActive(true);

        navigator.enabled = true;

        MoveNav(0);

    }

	void Update () {
        #region Player 1 Navigation functions

		if(Input.GetKeyDown(KeyCode.A)){
            if (_navPos == 12){
                _navPos = 0;
                navigator.transform.position = slots[_navPos].position;
            }else{
                MoveNav(1);
            }
            
            // DisplayCharacter(1, _nav1Pos);

		}

        if(Input.GetKeyDown(KeyCode.D)){
			if (_navPos == 0){
                _navPos = 12;
                navigator.transform.position = slots[_navPos].position;
            }else{
                MoveNav(-1);
            }
            // DisplayCharacter(1, _nav1Pos);
		}

        if(Input.GetKeyDown(KeyCode.E)){
            if (_isMapSelected){
                StartGame();
            }
            if(!_isMapSelected){
                navigator.enabled = false;
                // selectedCharacterSpriteP1.enabled = true;
                // selectedCharacterSpriteP1.transform.position = slots[_nav1Pos].position;
                _isMapSelected = true;
                _selectedMap = _navPos;
                startGameNavigator.enabled = true;
                startGameNavigator.transform.position = startButton.transform.position;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            if (_isMapSelected){
                navigator.enabled = true;
                startGameNavigator.enabled = false;
                _isMapSelected = false;
                // selectedCharacterSpriteP1.enabled = false;
            }
        }

        #endregion
	}

	void MoveNav(int change){
        if(change > 0){
            if(_navPos + change < slots.Length - 1){
                _navPos += change;
            }else{
                _navPos = slots.Length-1;
            }
        }else{
            if(_navPos + change >= 0){
                _navPos += change;
            }else{
                _navPos = 0;
            }
        }
        navigator.transform.position = slots[_navPos].position;
	}

    // private void DisplayCharacter(int indexCharacter) {
    //     switch (player){
    //         case 1:
    //             foreach (var character in charactersPlayer1){
    //                 character.SetActive(false);
    //             }
    //             charactersPlayer1[indexCharacter].SetActive(true);
    //             break;
    //         case 2:
    //             foreach (var character in charactersPlayer2){
    //                 character.SetActive(false);
    //             }
    //             charactersPlayer2[indexCharacter].SetActive(true);  
    //             break;
    //         default:
    //             Debug.Log("Error in selection");
    //             break;
    //         }
    // }

    public void StartGame(){
        PlayerPrefs.SetInt("selectedMap", _selectedMap);
        // SceneManager.LoadScene(1, LoadSceneMode.Single);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

}

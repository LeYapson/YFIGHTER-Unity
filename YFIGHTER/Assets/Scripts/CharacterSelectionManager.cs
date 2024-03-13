using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    [Header("Player 1 Parameters")]
    [SerializeField] private int _selectedCharacterP1 = 0;
    [SerializeField] private bool _isCharacterSelectedP1 = false;
    public GameObject[] charactersPlayer1;

    [Header("Player 1 Selection UI/Images")]
    [SerializeField] private int _nav1Pos = 0;
    public Image navigator1;
    public Image selectedCharacterSpriteP1;

    [Header("Player 2 Parameters")]
    [SerializeField] private int _selectedCharacterP2 = 1;
    [SerializeField] private bool _isCharacterSelectedP2 = false;
    public GameObject[] charactersPlayer2;
    
    [Header("Player 2 Selection UI/Images")]
    [SerializeField] int _nav2Pos = 0;
    public Image navigator2;
    public Image selectedCharacterSpriteP2;

    [Header("Start Button Selection UI/Images")]
    public Button startButton;
    public Image startGameNavigator;
	public RectTransform[] slots;

    private void Start(){
        charactersPlayer1[_selectedCharacterP1].SetActive(true);
        charactersPlayer2[_selectedCharacterP2].SetActive(true);
        navigator1.enabled = true;
        navigator2.enabled = true;

        MoveNav(1, 0);
        MoveNav(2, 1);
    }

	void Update () {
        #region Player 1 Navigation functions

		if(Input.GetKeyDown(KeyCode.A)){
            if(!_isCharacterSelectedP1){
                MoveNav(1, -1);
                DisplayCharacter(1, _nav1Pos);
            }
		}

        if(Input.GetKeyDown(KeyCode.D)){
			MoveNav(1, 1);
            DisplayCharacter(1, _nav1Pos);
		}

        if(Input.GetKeyDown(KeyCode.E)){
            if (_isCharacterSelectedP1 && _isCharacterSelectedP2){
                StartGame();
            }
            if(!_isCharacterSelectedP1){
                navigator1.enabled = false;
                selectedCharacterSpriteP1.enabled = true;
                selectedCharacterSpriteP1.transform.position = slots[_nav1Pos].position;
                _isCharacterSelectedP1 = true;
                _selectedCharacterP1 = _nav1Pos;
                startGameNavigator.enabled = true;
                startGameNavigator.transform.position = startButton.transform.position;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            if (_isCharacterSelectedP1){
                navigator1.enabled = true;
                startGameNavigator.enabled = false;
                _isCharacterSelectedP1 = false;
                selectedCharacterSpriteP1.enabled = false;
            }
        }

        #endregion

        #region Player 2 Navigation functions

		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			MoveNav(2, -1);
            DisplayCharacter(2, _nav2Pos);
		}

        if(Input.GetKeyDown(KeyCode.RightArrow)){
			MoveNav(2, 1);
            DisplayCharacter(2, _nav2Pos);
		}

        if(Input.GetKeyDown(KeyCode.P)){
            if(!_isCharacterSelectedP2){
                selectedCharacterSpriteP2.enabled = true;
                selectedCharacterSpriteP2.transform.position = slots[_nav2Pos].position;
                _isCharacterSelectedP2 = true;
                _selectedCharacterP2 = _nav2Pos;
            }
        }

        if(Input.GetKeyDown(KeyCode.O)){
            if(_isCharacterSelectedP2){
                _isCharacterSelectedP2 = false;
                selectedCharacterSpriteP2.enabled = false;
            }
        }

        #endregion

		#region Start Button interactable

        if (_isCharacterSelectedP1 && _isCharacterSelectedP2){
            startButton.interactable = true;
        } else {
            startButton.interactable = false;
        }

        #endregion
	}

	void MoveNav(int player, int change){
        switch (player){
            case 1:
                    if(!_isCharacterSelectedP1){
                    if(change > 0){
                        if(_nav1Pos + change < slots.Length - 1){
                            _nav1Pos += change;
                        }else{
                            _nav1Pos = slots.Length-1;
                        }
                    }else{
                        if(_nav1Pos + change >= 0){
                            _nav1Pos += change;
                        }else{
                            _nav1Pos = 0;
                        }
                    }
                    navigator1.transform.position = slots[_nav1Pos].position;
                }
                break;
            case 2:
                if(!_isCharacterSelectedP2){
                    if(change > 0){
                        if(_nav2Pos + change < slots.Length - 1){
                            _nav2Pos += change;
                        }else{
                            _nav2Pos = slots.Length-1;
                        }
                    }else{
                        if(_nav2Pos+change >= 0){
                            _nav2Pos += change;
                        }else{
                            _nav2Pos = 0;
                        }
                    }
                    navigator2.transform.position = slots[_nav2Pos].position;
                }
                break;
            default:
                Debug.Log("Error in selection");
                break;
            }
	}

    private void DisplayCharacter(int player, int indexCharacter) {
        switch (player){
            case 1:
                foreach (var character in charactersPlayer1){
                    character.SetActive(false);
                }
                charactersPlayer1[indexCharacter].SetActive(true);
                break;
            case 2:
                foreach (var character in charactersPlayer2){
                    character.SetActive(false);
                }
                charactersPlayer2[indexCharacter].SetActive(true);  
                break;
            default:
                Debug.Log("Error in selection");
                break;
            }
    }

    public void StartGame(){
        PlayerPrefs.SetInt("selectedCharacterP1", _selectedCharacterP1);
        PlayerPrefs.SetInt("selectedCharacterP2", _selectedCharacterP2);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}

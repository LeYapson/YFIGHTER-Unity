using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPointP1;
    public Transform spawnPointP2;

    void Start(){
        int selectedCharacterP1 = PlayerPrefs.GetInt("selectedCharacterP1");
        int selectedCharacterP2 = PlayerPrefs.GetInt("selectedCharacterP2");
        GameObject prefabP1 = characterPrefabs[selectedCharacterP1];
        GameObject prefabP2 = characterPrefabs[selectedCharacterP2];
        GameObject cloneP1 = Instantiate(prefabP1, spawnPointP1.position, Quaternion.identity);
        GameObject cloneP2 = Instantiate(prefabP2, spawnPointP2.position, Quaternion.identity);
    }
}

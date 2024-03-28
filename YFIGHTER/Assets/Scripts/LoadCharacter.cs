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
        Debug.Log(PlayerPrefs.GetInt("selectedMap"));
        int selectedCharacterP1 = PlayerPrefs.GetInt("selectedCharacterP1");
        int selectedCharacterP2 = PlayerPrefs.GetInt("selectedCharacterP2");
        GameObject prefabP1 = characterPrefabs[selectedCharacterP1];
        GameObject prefabP2 = characterPrefabs[selectedCharacterP2];
        GameObject cloneP1 = Instantiate(prefabP1, spawnPointP1.position, Quaternion.identity);
        GameObject cloneP2 = Instantiate(prefabP2, spawnPointP2.position, Quaternion.identity);
        cloneP1.AddComponent<Player1Movements>();
        cloneP1.AddComponent<Player1Interactions>();
        cloneP1.tag = "Player1";
        cloneP1.GetComponent<Rigidbody>().useGravity = true;

        cloneP2.AddComponent<Player2Movements>();
        cloneP2.AddComponent<Player2Interactions>();
        cloneP2.tag = "Player2";
        cloneP2.GetComponent<Rigidbody>().useGravity = true;
    }
}

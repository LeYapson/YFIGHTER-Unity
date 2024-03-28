using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Interactions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if (collision.collider.CompareTag("Player1")){
            Debug.Log("PLayer 2 : Ouille j'ai mal");
        }
    }
}

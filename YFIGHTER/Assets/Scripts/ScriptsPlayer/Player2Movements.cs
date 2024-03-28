using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Movements : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    // Start is called before the first frame update

    public bool enableControls = false;

    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "CharacterSelection")
        {
            enableControls = false;
        }else {
            enableControls = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enableControls)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            // if (isGrounded && Input.GetKey(KeyCode.Space))
            // {
            //     GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //     isGrounded = false;
            //     isJumping = true;
            // }
        }

    }
}

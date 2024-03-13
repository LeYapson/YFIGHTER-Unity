using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float speed = 5.0f;

    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0.0f, speed * 3 * Time.deltaTime, 0.0f);
        }
    }
}

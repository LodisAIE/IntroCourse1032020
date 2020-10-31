using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementBehaviour : MonoBehaviour
{
    
    //Stores player direction for movement
    public Vector3 directionX;
    public Vector3 directionZ;
    //Applied to positions for player movment
    public Vector3 velocity;

    //Scales direction to get velocity
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    

    // Update is called once per frame
    void Update()
    {
        //Gets direction from the input axis
        directionX = transform.right * Input.GetAxis("Horizontal");
        directionZ = transform.forward * Input.GetAxis("Vertical");

        //Scales direction by speed and deltatime to find an appropriate velocity
        velocity = (directionZ + directionX) * speed * Time.deltaTime;

        //Increase the players position by the velocity value found
        transform.position = transform.position + velocity;
        
        transform.Rotate(0, (Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed), 0, Space.World);
    }
    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}

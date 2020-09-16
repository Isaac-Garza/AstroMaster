using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    public float horizontalOffset = -85.0f;
    public float verticalOffset = 200.0f;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if(player != null){
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = player.transform.position + (horizontalOffset * player.transform.forward) + (verticalOffset * Vector3.up);
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
        }
    }
}



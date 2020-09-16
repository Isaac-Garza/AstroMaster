using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShipMovementControl : MonoBehaviour
{
    public float velocity;
    public float rotationSpeed;
    public float tiltAngle;

    // Start is called before the first frame update
    void Start()
    {
        //inputController = GetComponent<ShipInputControl>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveManualRotation();
    }

  
    private void UpdateMoveManualRotation()
    {
        float tilt = Input.GetAxis("Horizontal") * tiltAngle; // might be negative, just test it
        this.transform.position += Input.GetAxis("Vertical") * this.transform.forward * velocity * Time.deltaTime;
        var rotationAmount = rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y + rotationAmount, -tilt);
    }



}

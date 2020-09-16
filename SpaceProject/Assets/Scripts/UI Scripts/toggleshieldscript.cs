using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleshieldscript : MonoBehaviour
{
    public GameObject shield;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shield != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                shield.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                shield.SetActive(false);
            }
        }
    }

    }



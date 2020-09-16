using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    private Random rand;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(Random.Range(5, 50), Random.Range(5, 50), Random.Range(5, 50));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using System.Collections;
 
public class PhysicalExplosion : MonoBehaviour 
{
    public float Radius;// explosion radius
    public float Force;// explosion forse
    void Update () 
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);// create explosion
        for(int i=0; i<hitColliders.Length; i++)
        {
            Debug.Log("This is what this is: " + hitColliders[i].tag);
            if (hitColliders[i].tag != "Money" || hitColliders[i].tag != "Energy" || hitColliders[i].tag != "Fuel")
            {
                //if (hitColliders[i].CompareTag("CanDestroy"))// if tag CanBeRigidbody
                {
                    if (!hitColliders[i].GetComponent<Rigidbody>())
                    {
                        hitColliders[i].gameObject.AddComponent<Rigidbody>();
                    }
                    hitColliders[i].GetComponent<Rigidbody>().AddExplosionForce(Force, transform.position, Radius, 0.0F); // push game object
                }
            }
			
        }
        Destroy(gameObject,0.2f);// destroy explosion
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }
}
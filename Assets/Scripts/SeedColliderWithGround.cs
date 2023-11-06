using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedColliderWithGround : MonoBehaviour
{
    public GameObject Flower; // The object to spawn when this one hits the ground

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plantable"))
        {

            // Calculate the hit location
            Vector3 hitPoint = collision.contacts[0].point;

            // Spawn a new object at the hit location
            Instantiate(Flower, hitPoint, Quaternion.identity);

            // Despawn this object
            Destroy(gameObject);
        }
    }
}
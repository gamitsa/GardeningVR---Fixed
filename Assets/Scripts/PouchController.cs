using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PouchController : MonoBehaviour
{
    [SerializeField] private GameObject seedPrefab;
    [SerializeField] private float dropCooldown = 1f;
    [SerializeField] private Transform spawnPoint;

    private bool canDropSeed = true;
    private bool isUpsideDown = false; // Flag to track the pouch orientation

    private void Update()
    {
        // Check if the pouch is upside down
        if (transform.rotation.eulerAngles.z > 145f && transform.rotation.eulerAngles.z < 225f)
        {
            isUpsideDown = true;
        }
        else
        {
            isUpsideDown = false;
        }

        if (isUpsideDown && canDropSeed)
        {
            DropSeed();
        }
    }

    void DropSeed()
    {
        Instantiate(seedPrefab, spawnPoint.position, Quaternion.identity);
        canDropSeed = false;
        StartCoroutine(StartCooldown());
    }
    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(dropCooldown);
        canDropSeed = true;
    }
}

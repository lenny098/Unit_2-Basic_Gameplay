using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float lastDog;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time - lastDog) > 1)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            lastDog = Time.time;
        }
    }
}

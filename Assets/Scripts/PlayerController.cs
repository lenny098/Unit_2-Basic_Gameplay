using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;

    public float xBound = 10;
    public float zBound = 15;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // Bound
        // transform.position = Vector3.ClampMagnitude(transform.position, xBound);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -xBound, xBound),
            transform.position.y,
            Mathf.Clamp(transform.position.z, 0, zBound)
        );

        // Fire Projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 playerPosition = transform.position;
            Vector3 projecttilePosition = new Vector3(
                playerPosition.x,
                projectilePrefab.transform.position.y,
                playerPosition.z + 1 // prevent collision with player
            );

            Instantiate(projectilePrefab, projecttilePosition, projectilePrefab.transform.rotation);
        }
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;

    public float xBound = 10;
    public float zBound = 15;

    public GameObject projectilePrefab;

    void CreateProjectile()
    {
        Vector3 projecttilePosition = transform.position;
        projecttilePosition.y = projectilePrefab.transform.position.y;

        Instantiate(projectilePrefab, projecttilePosition, projectilePrefab.transform.rotation);
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
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -xBound, xBound),
            transform.position.y,
            Mathf.Clamp(transform.position.z, 0, zBound)
        );

        // Fire Projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Animal (Without Health)":
                ScoreManager.Instance.DecreaseLives();

                break;
            case "Animal (With Health)":
                ScoreManager.Instance.DecreaseLives();

                break;
            default:
                break;
        }
    }
}

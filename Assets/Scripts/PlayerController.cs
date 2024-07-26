using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    Bounds bounds;
    public GameObject projectilePrefab;

    float horizontalInput;
    float verticalInput;

    void Move()
    {
        // Move
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // Bound
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bounds.min.x, bounds.max.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, bounds.min.z, bounds.max.z)
        );
    }

    void CreateProjectile()
    {
        Vector3 projecttilePosition = transform.position;
        projecttilePosition.y = projectilePrefab.transform.position.y;

        Instantiate(projectilePrefab, projecttilePosition, projectilePrefab.transform.rotation);
    }

    private void Awake()
    {
        bounds = GameObject.Find("Player Bound").GetComponent<Renderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Move();

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

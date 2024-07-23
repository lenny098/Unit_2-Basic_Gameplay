using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private Bounds bounds = new Bounds(
        new Vector3(0, 0, 10),
        new Vector3(50, 5, 30)
    );

    // Update is called once per frame
    void Update()
    {
        if (!bounds.Contains(transform.position))
        {
            Destroy(gameObject);

            // Check whether this game object is projectile
            if (transform.position.z < bounds.max.z)
            {
                ScoreManager.Instance.DecreaseLives();
            }
        }
    }
}

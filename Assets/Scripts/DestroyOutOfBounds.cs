using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    Bounds bounds;

    private void Awake()
    {
        bounds = GameObject.Find("Bound").GetComponent<Renderer>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        if (bounds.Contains(transform.position)) return;

        switch (tag)
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

        Destroy(gameObject);
    }
}

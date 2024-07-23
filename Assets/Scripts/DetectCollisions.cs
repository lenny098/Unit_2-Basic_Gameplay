using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Animal (Without Health)":
                Destroy(gameObject);
                Destroy(other.gameObject);

                ScoreManager.Instance.IncreaseScore();

                break;
            case "Animal (With Health)":
                Destroy(gameObject);

                break;
            default:
                break;
        }
    }
}

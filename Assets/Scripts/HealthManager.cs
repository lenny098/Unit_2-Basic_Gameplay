using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int maxHunger;
    int hunger = 0;

    [SerializeField] GameObject canvas;
    [SerializeField] Slider hungerSlider;

    // Start is called before the first frame update
    void Start()
    {
        canvas.transform.rotation = Quaternion.LookRotation(Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Food")) return;

        hunger++;
        hungerSlider.value = (float)hunger / maxHunger;

        if (hunger >= maxHunger)
        {
            Destroy(gameObject);
            ScoreManager.Instance.IncreaseScore();
        }
    }
}

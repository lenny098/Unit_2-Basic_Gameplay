using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth = 0;

    public GameObject canvas;
    public Slider health;

    // Start is called before the first frame update
    void Start()
    {
        canvas.transform.rotation = Quaternion.LookRotation(Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        health.value = currentHealth / maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Food")) return;

        currentHealth = Mathf.Min(currentHealth + 1, maxHealth);

        if (currentHealth >= maxHealth)
        {
            Destroy(gameObject);
            ScoreManager.Instance.IncreaseScore();
        }
    }
}

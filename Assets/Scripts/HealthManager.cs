using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth = 0;

    public GameObject canvas;
    public Slider health;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        canvas.transform.rotation = Quaternion.LookRotation(Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(currentHealth / maxHealth);
        health.value = currentHealth / maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Food")) return;

        currentHealth = Mathf.Min(currentHealth + 1, maxHealth);

        if (currentHealth >= maxHealth)
        {
            Destroy(gameObject);
            scoreManager.IncreaseScore();
        }
    }
}

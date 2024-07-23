using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public float spawnXBound;
    public float spawnZ;

    public float startDelay;
    public float spawnInterval;

    GameObject GetRandomAnimal()
    {
        int spawnIndex = Random.Range(0, animalPrefabs.Length);
        return animalPrefabs[spawnIndex];
    }

    void SpawnRandomAnimal()
    {
        GameObject animal = GetRandomAnimal();

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnXBound, spawnXBound), 0, spawnZ);
        Instantiate(animal, spawnPosition, Quaternion.LookRotation(Vector3.back));
    }

    void SpawnRandomAnimalLeft()
    {
        GameObject animal = GetRandomAnimal();

        Vector3 spawnPosition = new Vector3(-spawnXBound - 5, 0, Random.Range(0, 15.0f));

        Instantiate(animal, spawnPosition, Quaternion.LookRotation(Vector3.right));
    }

    void SpawnRandomAnimalRight()
    {
        GameObject animal = GetRandomAnimal();

        Vector3 spawnPosition = new Vector3(spawnXBound + 5, 0, Random.Range(0, 15.0f));

        Instantiate(animal, spawnPosition, Quaternion.LookRotation(Vector3.left));
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalLeft", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
    }
}

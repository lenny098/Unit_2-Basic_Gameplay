using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    [SerializeField] GameObject spawnBoundTop;
    [SerializeField] GameObject spawnBoundLeft;
    [SerializeField] GameObject spawnBoundRight;

    [SerializeField] float startDelay;
    [SerializeField] float spawnInterval;

    Bounds topBounds;
    Bounds leftBounds;
    Bounds rightBounds;

    GameObject GetRandomAnimal()
    {
        int spawnIndex = Random.Range(0, animalPrefabs.Length);

        return animalPrefabs[spawnIndex];
    }

    void SpawnRandomAnimalTop()
    {
        GameObject animal = GetRandomAnimal();
        Vector3 position = new Vector3(Random.Range(topBounds.min.x, topBounds.max.x), 0, topBounds.center.z);
        Quaternion rotation = Quaternion.LookRotation(Vector3.back);

        Instantiate(animal, position, rotation);
    }

    void SpawnRandomAnimalLeft()
    {
        GameObject animal = GetRandomAnimal();
        Vector3 position = new Vector3(leftBounds.center.x, 0, Random.Range(leftBounds.min.z, leftBounds.max.z));
        Quaternion rotation = Quaternion.LookRotation(Vector3.right);

        Instantiate(animal, position, rotation);
    }

    void SpawnRandomAnimalRight()
    {
        GameObject animal = GetRandomAnimal();
        Vector3 position = new Vector3(rightBounds.center.x, 0, Random.Range(rightBounds.min.z, rightBounds.max.z));
        Quaternion rotation = Quaternion.LookRotation(Vector3.left);

        Instantiate(animal, position, rotation);
    }

    private void Awake()
    {
        topBounds = spawnBoundTop.GetComponent<Renderer>().bounds;
        leftBounds = spawnBoundLeft.GetComponent<Renderer>().bounds;
        rightBounds = spawnBoundRight.GetComponent<Renderer>().bounds;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalTop", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalLeft", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
    }
}

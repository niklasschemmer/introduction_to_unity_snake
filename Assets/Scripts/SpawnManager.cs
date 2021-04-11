using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject _flowerOnePrefab;
    [SerializeField]
    public GameObject _grassOnePrefab;
    [SerializeField]
    public GameObject _grassTwoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InstanciateFlowers();
        InstanciateGrassOne();
        InstanciateGrassTwo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InstanciateFlowers()
    {
        var flowers = Random.Range(150, 200);
        for (int i = 0; i < flowers; i++)
        {
            Instantiate(_flowerOnePrefab, new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-5f, 15f)), Quaternion.Euler(0, Random.Range(0, 360f), 0));
        }
    }

    private void InstanciateGrassOne()
    {
        var flowers = Random.Range(1000, 1100);
        for (int i = 0; i < flowers; i++)
        {
            Instantiate(_grassOnePrefab, new Vector3(Random.Range(-30f, 30f), 0, Random.Range(-10f, 15f)), Quaternion.Euler(0, Random.Range(0, 360f), 0));
        }
    }

    private void InstanciateGrassTwo()
    {
        var flowers = Random.Range(1000, 1100);
        for (int i = 0; i < flowers; i++)
        {
            Instantiate(_grassTwoPrefab, new Vector3(Random.Range(-30f, 30f), 0, Random.Range(-10f, 15f)), Quaternion.Euler(0, Random.Range(0, 360f), 0));
        }
    }
}

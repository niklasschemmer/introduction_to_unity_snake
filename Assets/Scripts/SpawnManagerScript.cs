using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject _flowerOnePrefab;
    [SerializeField]
    public GameObject _grassOnePrefab;
    [SerializeField]
    public GameObject _grassTwoPrefab;
    [SerializeField]
    public GameObject _applePrefab;
    [SerializeField]
    public BodyPartFirst bodyPartFirst;
    [SerializeField]
    public TextMeshPro scoreBoard;
    [SerializeField]
    public TextMeshPro gameOverText;

    private GameObject _apple;
    private int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        InstanciateFlowers();
        InstanciateGrassOne();
        InstanciateGrassTwo();
        InstanciateApple();
        gameOverText.gameObject.SetActive(false);
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

    private void InstanciateApple()
    {
        var zVal = Random.Range(-6f, 9f);
        _apple = Instantiate(_applePrefab, new Vector3(Random.Range(-21f + zVal * 0.5f, 21f + zVal * -0.5f), 0.1f, zVal), Quaternion.Euler(-90, Random.Range(0, 360f), 0));
    }

    public void EatApple()
    {
        bodyPartFirst.AddBodyPart();
        bodyPartFirst.AddBodyPart();
        bodyPartFirst.AddBodyPart();
        bodyPartFirst.AddBodyPart();
        Destroy(_apple);
        InstanciateApple();
        _score++;
        scoreBoard.text = "Your score: " + _score;
    }

    public IEnumerator TouchedSelf()
    {
        if(PlayerPrefs.GetInt("highscore", 0) < _score)
            PlayerPrefs.SetInt("highscore", _score);

        gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}

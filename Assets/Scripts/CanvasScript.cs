using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    [SerializeField]
    public GameObject _mainMenuContainer;
    [SerializeField]
    public TextMeshProUGUI creatorsText;
    [SerializeField]
    public TextMeshProUGUI tutorialText;
    [SerializeField]
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        creatorsText.gameObject.SetActive(false);
        tutorialText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        backButton.onClick.AddListener(BackButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButtonClick()
    {
        ShowCreators(false);
        ShowTutorial(false);
    }

    public void ShowCreators(bool show)
    {
        backButton.gameObject.SetActive(show);
        _mainMenuContainer.gameObject.SetActive(!show);
        creatorsText.gameObject.SetActive(show);
    }

    public void ShowTutorial(bool show)
    {
        backButton.gameObject.SetActive(show);
        _mainMenuContainer.gameObject.SetActive(!show);
        tutorialText.gameObject.SetActive(show);
    }
}

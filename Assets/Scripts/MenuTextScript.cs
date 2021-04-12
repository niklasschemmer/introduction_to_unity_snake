using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuTextScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public TextMeshProUGUI text;
    [SerializeField]
    public CanvasScript menuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        if (CompareTag("Startgame"))
        {
            SceneManager.LoadScene("Game");
        }
        else if (CompareTag("Exitgame"))
        {
            Application.Quit();
        }
        else if (CompareTag("Showcreators"))
        {
            menuCanvas.ShowCreators(true);
        }
        else if (CompareTag("Showtutorial"))
        {
            menuCanvas.ShowTutorial(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = new Color(0, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = new Color(255, 255, 255);
    }
}

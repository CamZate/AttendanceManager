using UnityEngine;
using UnityEngine.UI;

public class sidebarAnimation : MonoBehaviour
{

    [SerializeField] private float openPositionX = 280f;
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private Vector3 currentPosition;


    [SerializeField] private Button menusButton;
    [SerializeField] private bool isOpen = false;

    [SerializeField] private float duration = 1f;
    private RectTransform rt;

    [SerializeField] private GameObject shade;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        isOpen = false;
        currentPosition = rt.localPosition;
        menusButton.onClick.AddListener(ToggleSidebar);
    }

    void ToggleSidebar()
    {
        CanvasGroup canvasGroup = shade.GetComponent<CanvasGroup>();
        currentPosition = rt.localPosition;
        if (!isOpen)
        {
            gameObject.LeanMoveLocal(currentPosition + Vector3.left * openPositionX, duration).setEaseOutQuart();
            shade.SetActive(true);
            canvasGroup.LeanAlpha(0.8f, duration).setEaseOutQuart();
            isOpen = true;
        }
        else
        {
            gameObject.LeanMoveLocal(currentPosition + Vector3.left * -openPositionX, duration).setEaseOutQuart();
            canvasGroup.LeanAlpha(0f, duration).setEaseOutQuart().setOnComplete(() => shade.SetActive(false));
            isOpen = false;
        }
    }
}

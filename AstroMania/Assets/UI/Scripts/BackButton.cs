using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject currentScreen;
    [SerializeField] private GameObject previousScreen;

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            currentScreen.SetActive(false);
            previousScreen.SetActive(true);
        });
    }
}
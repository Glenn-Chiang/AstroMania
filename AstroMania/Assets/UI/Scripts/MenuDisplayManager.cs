using UnityEngine;

public class MenuDisplayManager : MonoBehaviour
{
    public static MenuDisplayManager Instance { get; private set; }
    public int NumMenusShown { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void OnMenuShown()
    {
        if (NumMenusShown == 0)
        {
            Time.timeScale = 0;
        }
        NumMenusShown++;
    }

    public void OnMenuHidden()
    {
        NumMenusShown--;
        if (NumMenusShown == 0)
        {
            Time.timeScale = 1;
        }
    }
}
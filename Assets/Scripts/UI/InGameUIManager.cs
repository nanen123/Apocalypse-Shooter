using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    private InputAction escAction;
    public GameObject escMenu;

    public bool isESC;

    private void Awake()
    {
        escAction = InputSystem.actions.FindAction("ESC");
    }

    void Update()
    {
        if(escAction.ReadValue<float>() == 1)
        {
            OpenEsc();
        }
    }
    public void OpenEsc()
    {
        Time.timeScale = 0;
        isESC = true;
        escMenu.SetActive(true);
    }
    public void BackToGame()
    {
        Time.timeScale = 1;
        isESC = false;
        escMenu.SetActive(false);
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

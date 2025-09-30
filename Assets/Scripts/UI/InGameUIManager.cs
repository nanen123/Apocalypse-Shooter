using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    private InputAction escAction;
    public GameObject escMenu;

    private HealthComponent ph;

    public bool isESC;

    private void Awake()
    {
        escAction = InputSystem.actions.FindAction("ESC");
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthComponent>();
        ph.onDeadAction += PlayerDied;
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

    private void PlayerDied()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

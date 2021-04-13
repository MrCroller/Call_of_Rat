using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingPanel;
    private Animator menuAnim;

    bool flag_options = false;

    public void Awake()
    {
        menuAnim = gameObject.GetComponent<Animator>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("CallofRat");
    }

    public void ClickOptions()
    {
        menuAnim.SetBool("Options", flag_options = !flag_options);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}

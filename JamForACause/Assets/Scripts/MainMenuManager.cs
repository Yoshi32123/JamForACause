using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject instructionsMenu;

    void Start()
    {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
    }

    public void ClickPlay()
    {
        SceneManager.LoadScene("Level");
    }

    public void ClickInstructions()
    {
        mainMenu.SetActive(false);
        instructionsMenu.SetActive(true);
    }

    public void ClickQuit()
    {
        Application.Quit();
    }

    public void ClickBack()
    {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
    }
}

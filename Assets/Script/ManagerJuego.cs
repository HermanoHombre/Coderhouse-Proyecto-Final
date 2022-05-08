using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerJuego : MonoBehaviour
{
    public static ManagerJuego instancia;
    AudioSource _audiosource;
    public static int presentScene = 0;

    public static void NextScenee()
    {
        presentScene++;
        SceneManager.LoadScene(presentScene);
    }
    public static void NextScene()
    {
        presentScene++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void PreviousScene()
    {
        presentScene++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public static void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    
}

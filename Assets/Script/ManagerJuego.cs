using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerJuego : MonoBehaviour
{
    public static ManagerJuego instancia;
    AudioSource _audiosource;
    public static int presentScene = 0;

    public static void Pausa()
    {
        instancia._audiosource.Pause();
    }

    public static void Despausar()
    {
        instancia._audiosource.UnPause();
    }

    public static void NextScene()
    {
        presentScene++;
        SceneManager.LoadScene(presentScene);
    }
}

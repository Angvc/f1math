using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuControl : MonoBehaviour
{
    public int targetframerate = 24;
    [SerializeField] private GameObject Menubgm;
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetframerate;
    }

    public void buttonSingleplayer()
    {
        Menubgm.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void buttonMultiplayer()
    {
        Menubgm.SetActive(false);
        SceneManager.LoadScene(2);
    }

    public void buttonQuit()
    {
        Application.Quit();
    }

    public void buttonBacktomenu()
    {
        SceneManager.LoadScene(0);
    }
}

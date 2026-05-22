using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LooseScreen;
    public ParticleSystem particles;


// Start is called once before the first execution of Update after the MonoBehaviour is created
    public TimerBehaviour timer;
    void Start()
    {
        WinScreen.SetActive(false);
        LooseScreen.SetActive(false);
    }

    public void TriggerWinState()
    {
        WinScreen.SetActive(true);
        Time.timeScale = 0f;
        particles.Play();
    }

    public void TriggerLooseState()
    {
        LooseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GotoGame()
    {
      SceneManager.LoadScene("SampleScene");
      Time.timeScale = 1f;
    }

    public void Restart()
    {
        //Reloads current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

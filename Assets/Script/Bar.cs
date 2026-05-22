using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float progress;
    public float totaltime;
    public Image BarImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Keyboard.current.spaceKey.isPressed)
        {
            progress += Time.deltaTime;
            BarImage.fillAmount = progress / totaltime;
        }
    }
}

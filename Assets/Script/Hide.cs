using UnityEngine;
using UnityEngine.InputSystem;

public class Hide : MonoBehaviour
{
    public bool isHidden;

    public SpriteRenderer hiddenRender;
    public ParticleSystem particles;

    public Color hiddenColor;
    public Color notHiddenColor;
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isHidden = Keyboard.current.spaceKey.isPressed;
        if (isHidden)
        {
            animator.SetBool("isHidden", true);
        }
        else
        {
            animator.SetBool("isHidden", false);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            particles.Play();
        }
    }
}

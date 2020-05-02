using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{

    public Animator animator;

    public bool fadeStartWhite = false;

    public static string nextScene;

    public static bool fading = true;

    private bool fadeReady = false;

    private SpriteRenderer spriteRenderer;

    private Color gray = new Color(0.2f, 0.2f, 0.2f, 1);
    private Color white = new Color(1, 1, 1, 1);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (fadeStartWhite) {
            spriteRenderer.color = white;
        } else {
            spriteRenderer.color = gray;
        }
    }

    void Update()
    {
        if (fading && fadeReady) {
            animator.SetBool("FadeEnd", true);
        }
    }

    void StopFade() {
        fading = false;
        fadeReady = true;
        spriteRenderer.color = gray;
    }

    void SwitchScene() {
        SceneManager.LoadScene(nextScene);
    }
}

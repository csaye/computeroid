using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{

    public Animator animator;

    public GameObject levelSelector;

    private LevelSelector levelSelectorScript;

    private SpriteRenderer spriteRenderer;

    // Paper positioning in scene
    private float row1 = -1.062623f, row2 = 0.9373763f, row3 = 2.937376f;
    private float col1 = -5.250119f, col2 = -1.750129f, col3 = 1.749876f, col4 = 5.249878f;
    
    void Start()
    {
        levelSelectorScript = levelSelector.GetComponent<LevelSelector>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition() {
        if (levelSelectorScript.currentPos == 1) transform.position = new Vector2(col1, row1);
        if (levelSelectorScript.currentPos == 2) transform.position = new Vector2(col2, row1);
        if (levelSelectorScript.currentPos == 3) transform.position = new Vector2(col3, row1);
        if (levelSelectorScript.currentPos == 4) transform.position = new Vector2(col4, row1);
        if (levelSelectorScript.currentPos == 5) transform.position = new Vector2(col4, row2);
        if (levelSelectorScript.currentPos == 6) transform.position = new Vector2(col3, row2);
        if (levelSelectorScript.currentPos == 7) transform.position = new Vector2(col2, row2);
        if (levelSelectorScript.currentPos == 8) transform.position = new Vector2(col1, row2);
        if (levelSelectorScript.currentPos == 9) transform.position = new Vector2(col1, row3);
        if (levelSelectorScript.currentPos == 10) transform.position = new Vector2(col2, row3);
        if (levelSelectorScript.currentPos == 11) transform.position = new Vector2(col3, row3);
        if (levelSelectorScript.currentPos == 12) transform.position = new Vector2(col4, row3);
    }

    void LevelLoad() {
        spriteRenderer.GetComponent<Renderer>().enabled = false;
        animator.SetBool("PaperOut", true);
    }
}

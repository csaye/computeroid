using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    public Sprite levelSelect1, levelSelect2, levelSelect3, levelSelect4, levelSelect5, levelSelect6, levelSelect7, levelSelect8, levelSelect9, levelSelect10, levelSelect11, levelSelect12, levelSelectComplete;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateBackground();        
    }

    void UpdateBackground() {
        if (LevelManager.level == 1) spriteRenderer.sprite = levelSelect1;
        if (LevelManager.level == 2) spriteRenderer.sprite = levelSelect2;
        if (LevelManager.level == 3) spriteRenderer.sprite = levelSelect3;
        if (LevelManager.level == 4) spriteRenderer.sprite = levelSelect4;
        if (LevelManager.level == 5) spriteRenderer.sprite = levelSelect5;
        if (LevelManager.level == 6) spriteRenderer.sprite = levelSelect6;
        if (LevelManager.level == 7) spriteRenderer.sprite = levelSelect7;
        if (LevelManager.level == 8) spriteRenderer.sprite = levelSelect8;
        if (LevelManager.level == 9) spriteRenderer.sprite = levelSelect9;
        if (LevelManager.level == 10) spriteRenderer.sprite = levelSelect10;
        if (LevelManager.level == 11) spriteRenderer.sprite = levelSelect11;
        if (LevelManager.level == 12) spriteRenderer.sprite = levelSelect12;
        if (LevelManager.level > 12) spriteRenderer.sprite = levelSelectComplete;
    }
}

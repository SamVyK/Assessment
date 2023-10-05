using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites = new Sprite[0];
    public float animationTime = 0.25f;
    public int animationFrame { get; private set; }
    public bool loop = true;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InvokeRepeating(nameof(Advance), animationTime, animationTime);
    }

    void Advance()
    {
        if (!spriteRenderer.enabled)
        {
            return;
        }
        animationFrame++;
        if (animationFrame >= sprites.Length && loop)
        {
            animationFrame = 0;
        }
        if (animationFrame >= 0 && animationFrame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[animationFrame];
        }
    }

    public void Restart()
    {
        animationFrame = -1;
        Advance();
    }
    // Update is called once per frame
    void Update()
    {

    }
}

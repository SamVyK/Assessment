using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class EnemyWeak : EnemyBehavior
{

    public SpriteRenderer mainEye;
    public SpriteRenderer weak;
    public SpriteRenderer lessWeak;
    public bool killed { get; private set; }

    public override void EnableEnemy(float period)
    {
        base.EnableEnemy(period);
        this.mainEye.enabled = false;
        this.weak.enabled = true;
        this.lessWeak.enabled = false;
        Invoke(nameof(Blink), period / 2.0f);
    }

    void Blink()
    {
        this.weak.enabled = false;
        this.lessWeak.enabled = true;
        this.weak.GetComponent<EnemyAnimation>().Restart();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

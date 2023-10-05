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
        if(!this.killed)
        {
            this.weak.enabled = false;
            this.lessWeak.enabled = true;
            this.weak.GetComponent<EnemyAnimation>().Restart();
        }
        
    }
    public override void DisableEnemy()
    {
        base.DisableEnemy();
        this.mainEye.enabled = true;
        this.weak.enabled = false;
        this.lessWeak.enabled = false;
    }

    void OnEnable()
    {
        this.enemy.enemyMovement.velocityMulti = 0.05f;
        this.killed = false;
    }

    void OnDisable()
    {
        this.enemy.enemyMovement.velocityMulti = 1.0f;
        this.killed = false;
    }

    void Killed()
    {
        this.killed = true;
        Vector3 pos = this.enemy.enemyBase.baseTransformInside.position;
        pos.z = this.enemy.transform.position.z;
        this.enemy.transform.position = pos;    
        this.enemy.enemyBase.EnableEnemy(this.period);
        this.mainEye.enabled = false;
        this.weak.enabled = false;
        this.lessWeak.enabled = false;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (this.enabled)
            {
                Killed();
            }
        }
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

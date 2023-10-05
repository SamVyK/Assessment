using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int marks = 200;
    public EnemyMovement enemyMovement { get; private set; }
    public EnemyBase enemyBase { get; private set; }
    public EnemyChase enemyChase { get; private set; }
    public EnemyScatter enemyScatter { get; private set; }
    public EnemyWeak enemyWeak { get; private set; }
    public EnemyBehavior startingBehavior;
    public Transform attack;
    
    void Awake()
    {
        this.enemyMovement = GetComponent<EnemyMovement>();
        this.enemyBase = GetComponent<EnemyBase>();
        this.enemyChase = GetComponent<EnemyChase>();
        this.enemyScatter = GetComponent<EnemyScatter>();
        this.enemyWeak = GetComponent<EnemyWeak>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetPos();
    }

    public void ResetPos()
    {
        this.gameObject.SetActive(true);
        this.enemyMovement.ResetPos();
        this.enemyWeak.DisableEnemy();
        this.enemyChase.DisableEnemy();
        this.enemyScatter.EnableEnemy();
        if(this.enemyBase != this.startingBehavior)
        {
            this.enemyBase.DisableEnemy();
        }
        if(this.startingBehavior != null)
        {
            this.startingBehavior.EnableEnemy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(this.enemyWeak.enabled)
            {
                FindObjectOfType<Manager>().EnemyKilled(this);
            }
            else
            {
                FindObjectOfType<Manager>().PlayerKilled();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

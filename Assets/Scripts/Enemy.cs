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

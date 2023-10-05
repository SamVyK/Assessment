using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScatter : EnemyBehavior
{
    void OnDisable()
    {
        this.enemy.enemyChase.EnableEnemy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Point point = collision.GetComponent<Point>();
        if(point != null && this.enabled && !this.enemy.enemyWeak.enabled)
        {
            int index = Random.Range(0, point.turningPoints.Count);
            if (point.turningPoints[index] == -this.enemy.enemyMovement.direction && point.turningPoints.Count > 1)
            {
                index++;
                if(index >= point.turningPoints.Count)
                {
                    index = 0;  
                }
            }
            this.enemy.enemyMovement.SetPosDirec(point.turningPoints[index]);
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

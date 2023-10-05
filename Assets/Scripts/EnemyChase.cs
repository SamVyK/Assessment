using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyChase : EnemyBehavior
{
    void OnDisable()
    {
        this.enemy.enemyScatter.EnableEnemy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Point point = collision.GetComponent<Point>();
        if (point != null && this.enabled && !this.enemy.enemyWeak.enabled)
        {
            Vector2 direct = Vector2.zero;
            float MinimumDis = float.MaxValue;
            foreach (Vector2 turningPoint in point.turningPoints)
            {
                Vector3 newPos = this.transform.position + new Vector3(turningPoint.x, turningPoint.y, 0.0f);
                float length = (this.enemy.attack.position - newPos).sqrMagnitude;
                if(length < MinimumDis)
                {
                    direct = turningPoint;
                    MinimumDis = length;
                }
            }
            this.enemy.enemyMovement.SetPosDirec(direct);
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

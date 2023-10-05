using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBase : EnemyBehavior
{
    public Transform baseTransformInside;
    public Transform baseTransformOutide;

    void OnEnable()
    {
        StopAllCoroutines();
    }
    void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(EnemyExit());
        } 
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            this.enemy.enemyMovement.SetPosDirec(-this.enemy.enemyMovement.direction);
        }
    }
    IEnumerator EnemyExit()
    {
        this.enemy.enemyMovement.SetPosDirec(Vector2.up, true);
        this.enemy.enemyMovement.spriteBody.isKinematic = true;
        this.enemy.enemyMovement.enabled = false;
        Vector3 pos = this.transform.position;
        float period = 0.5f;
        float pass = 0.0f;
        while(pass < period)
        {
            Vector3 newPos = Vector3.Lerp(pos,this.baseTransformInside.position, pass / period);
            newPos.z = pos.z;
            this.enemy.transform.position = newPos;
            pass += Time.deltaTime;
            yield return null;
        }
        pass = 0.0f;
        while (pass < period)
        {
            Vector3 newPos = Vector3.Lerp(this.baseTransformInside.position, this.baseTransformOutide.position, pass / period);
            newPos.z = pos.z;
            this.enemy.transform.position = pos;
            pass += Time.deltaTime;
            yield return null;
        }
        this.enemy.enemyMovement.SetPosDirec(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f), true);
        this.enemy.enemyMovement.spriteBody.isKinematic = false;
        this.enemy.enemyMovement.enabled = true;
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

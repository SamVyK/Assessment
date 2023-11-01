using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public abstract class EnemyBehavior : MonoBehaviour
{
    public Enemy enemy { get ; private set; }
    public float period;
    private void Awake()
    {
        this.enemy = GetComponent<Enemy>();
        //this.enabled = false;
    }

    public void EnableEnemy()
    {
        EnableEnemy(this.period);
    }

    public virtual void EnableEnemy(float period)
    {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(DisableEnemy), period);
    }

    public virtual void DisableEnemy()
    {
        this.enabled = false;
        CancelInvoke();
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

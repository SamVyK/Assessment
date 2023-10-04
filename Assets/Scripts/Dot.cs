using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public int score = 10;

    protected virtual void ConsumeDots()
    {
        FindObjectOfType<Manager>().DotConsumed(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer ==LayerMask.NameToLayer("Player"))
        {
            ConsumeDots();
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

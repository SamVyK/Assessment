using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDot : Dot
{
    public float period = 8.0f;

    protected override void ConsumeDots()
    {
        FindObjectOfType<Manager>().BigDotConsumed(this);
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

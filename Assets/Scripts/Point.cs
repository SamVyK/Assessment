using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public List<Vector2> turningPoints { get; private set; }
    public LayerMask wallLayer;
    // Start is called before the first frame update
    void Start()
    {
        this.turningPoints = new List<Vector2>();
        CheckTurningPoints(Vector2.up);
        CheckTurningPoints(Vector2.down);
        CheckTurningPoints(Vector2.left);
        CheckTurningPoints(Vector2.right);
    }

    void CheckTurningPoints(Vector2 turningPiont)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, turningPiont, 1.0f, this.wallLayer);
        if(hit.collider == null)
        {
            this.turningPoints.Add(turningPiont);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

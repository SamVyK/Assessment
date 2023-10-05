using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{

    public Rigidbody2D spriteBody { get; private set; }
    public Vector2 direction { get; private set; }
    public Vector2 endingDirection { get; private set; }
    public Vector3 initialPos { get; private set; }
    public float velocity = 9.0f;
    public float velocityMulti = 1f;
    public Vector2 startingDirection;
    public LayerMask wallLayer;
    // Start is called before the first frame update

    void Awake()
    {
        this.spriteBody = GetComponent<Rigidbody2D>();
        this.initialPos = this.transform.position;
    }

    void Start()
    {
        ResetPos();
    }

    public void ResetPos()
    {
        this.velocityMulti = 1.0f;
        this.direction = this.startingDirection;
        this.endingDirection = Vector2.zero;
        this.transform.position = this.initialPos;
        this.spriteBody.isKinematic = false;
        this.enabled = true;
    }

    void FixedUpdate()
    {
        Vector2 pos = this.spriteBody.position;
        Vector2 trans = this.direction * this.velocity * this.velocityMulti * Time.fixedDeltaTime;
        this.spriteBody.MovePosition(pos + trans);
    }

    public void SetPosDirec(Vector2 direction, bool controlled = false)
    {
        if (controlled || !CheckSpace(direction))
        {
            this.direction = direction;
            this.endingDirection = Vector2.zero;
        }
        else
        {
            this.endingDirection = direction;
        }
    }

    public bool CheckSpace(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.wallLayer);
        return hit.collider != null;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.endingDirection != Vector2.zero)
        {
            SetPosDirec(this.endingDirection);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement { get; private set; }

     void Awake()
    {
        this.playerMovement = GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        { 
            this.playerMovement.SetPosDirec(Vector2.up); 
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.playerMovement.SetPosDirec(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.playerMovement.SetPosDirec(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.playerMovement.SetPosDirec(Vector2.left);
        }
    }

    public void ResetPos()
    {
        this.gameObject.SetActive(true);
        this.playerMovement.ResetPos();
    }
}

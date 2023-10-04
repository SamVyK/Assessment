using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Enemy[] enemies;
    public Player player;
    public Transform dots;
    public int total { get; private set; }
    public int playerLives { get; private set; }
    public int enemyMultiplier { get; private set; } = 1;

    // Start is called before the first frame update
     void Start()
    {
        SetGame();
    }

     void SetGame() 
    {
        SetTotal(0);
        SetPlayerLives(4);
        NewLvl();
    }

     void SetTotal(int total)
    {
        this.total = total;
    }

     void SetPlayerLives(int playerLives)
    {
        this.playerLives = playerLives;
    }

     void NewLvl() 
    {
        foreach(Transform dot in this.dots) 
        {
            dot.gameObject.SetActive(true);
        }
        ResetPos();
    }

      void ResetPos()
    {
        ResetEnemyMultiplier();
        for (int i = 0; i < enemies.Length; i++)
        {
            this.enemies[i].gameObject.SetActive(true);
        }
        this.player.gameObject.SetActive(true);
    }

     void GameEnd()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            this.enemies[i].gameObject.SetActive(false);
        }
        this.player.gameObject.SetActive(false);
    }

     void EnemyKilled(Enemy enemy)
    {
        SetTotal(this.total + (enemy.marks * this.enemyMultiplier));
        this.enemyMultiplier++;
    }

    void PlayerKilled() 
    {
        this.player.gameObject.SetActive(false);
        SetPlayerLives(this.playerLives - 1);
        if(this.playerLives > 0)
        {
            Invoke(nameof(ResetPos), 4.0f);
        }
        else
        {
            GameEnd();
        }
    }
    // Update is called once per frame
     void Update()
    {
        if (this.playerLives <= 0 && Input.anyKeyDown)
        {
            SetGame();
        }
    }

    public void DotConsumed(Dot dot)
    {
        dot.gameObject.SetActive(false);
        SetTotal(this.total + dot.score);
        if (!DotsThatleft())
        {
            this.player.gameObject.SetActive(false);
            Invoke(nameof(NewLvl), 3.0f);
        }
    }

    public void BigDotConsumed(BigDot dot)
    {
        DotConsumed(dot);
        CancelInvoke();
        Invoke(nameof(ResetEnemyMultiplier), dot.period);
    }
    private bool DotsThatleft()
    {
        foreach (Transform dot in this.dots)
        {
            if (dot.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

     void ResetEnemyMultiplier()
    {
        this.enemyMultiplier = 1;
    }
}

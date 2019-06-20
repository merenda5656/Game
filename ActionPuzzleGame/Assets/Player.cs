using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  // field
  GameObject enemy;
  private Rigidbody2D rigid2D;
  private static bool isTogether;
  private static bool hasKey;
  public LayerMask enemyLayer;

  // constractor
  public Player()
  {
    this.enemy = GameObject.Find("Enemy");
    this.rigid2D = GetComponent<Rigidbody2D>();
  }

  // static constractor
  static Player()
  {
    Player.isTogether = false;
    Player.hasKey = false;
  }


  void Start()
  {
  }

  void Update()
  {
    this.TouchEnemy();
    //base.XMove();
    //base.Jump();
  }

  public void TouchEnemy()
  {
    bool dec =
      Physics2D.Linecast(
        transform.position - transform.right * 1.0f,
        transform.position + transform.right * 1.0f,
        this.enemyLayer);

    Debug.DrawLine(
      transform.position - transform.right * 1.0f,
      transform.position + transform.right * 1.0f,
      Color.red);

    if (dec)
    {
      Debug.Log("Destroy!");
      Destroy(gameObject);
    }

  }

}

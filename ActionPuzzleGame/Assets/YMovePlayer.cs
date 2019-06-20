using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMovePlayer : MonoBehaviour
{

  // field
  private Rigidbody2D rigid2D;
  private readonly float jumpForce = 780.0f;
  private bool isGrounded;
  public LayerMask groundLayer;


  // getter
  public float GetJumpForce()
  {
    return this.jumpForce;
  }
  public bool GetIsGrounded()
  {
    return this.isGrounded;
  }


  void Start()
  {
    //this.jumpForce;
    this.rigid2D = GetComponent<Rigidbody2D>();
    this.isGrounded = false;
  }


  void Update()
  {
    //base.Update();
    //base.XMove();
    this.Jump();
  }


  // ジャンプする
  public void Jump()
  {
    if (Input.GetKeyDown(KeyCode.Space) && this.GetIsGrounded() )
    {
      Debug.Log("Jump!");
      // スペースキーが押され，ジャンプ中でなかったら
      this.rigid2D.AddForce(transform.up * this.GetJumpForce() );
    }

    // キャラクタが地面に接触しているかどうか判定
    isGrounded = Physics2D.Linecast(
        transform.position,
        transform.position - transform.up * 1.5f,
        this.groundLayer);

    // キャラクタが地面に接触しているかどうか判定する際に用いる線の描画
    // ただし，シーンビューで描画される(ゲームビューでは描画されない)
    Debug.DrawLine(
        transform.position,
        transform.position - transform.up * 1.5f,
        Color.red);
  }

}

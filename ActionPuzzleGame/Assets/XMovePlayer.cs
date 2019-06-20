using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMovePlayer : MonoBehaviour
{

  // field
  protected Rigidbody2D rigid2D;
  private readonly float walkForce = 300.0f;
  private readonly float maxWalkSpeed = 10.0f;

  // キャラクタの1フレーム前におけるx方向の向きを判定する変数
  // true: right, false: left
  bool preDir;
  // キャラクタの現在におけるx方向の向きを判定する変数
  // true: right, false: left
  bool currentDir;


  // getter
  //public Rigidbody2D GetRigidbody2D() { return this.rigid2D; }
  public float GetWalkForce()
  {
    return this.walkForce;
  }
  public float GetMaxWalkSpeed()
  {
    return this.maxWalkSpeed;
  }


  void Start()
  {
    this.rigid2D = GetComponent<Rigidbody2D>();
    this.preDir = true;
    this.currentDir = true;
  }



  void Update()
  {
    XMove();
  }


  // x方向に移動する．
  public void XMove()
  {
    // キャラクタが左右のどちらを向いているか判定する変数
    int key = 0;
    bool dec = false;


    if (Input.GetKey(KeyCode.RightArrow) )
    {
      // 右方向の移動
      key = 1;
      dec = true;
      currentDir = true;
    }
    if (Input.GetKey(KeyCode.LeftArrow) )
    {
      // 左方向の移動
      key = -1;
      dec = true;
      currentDir = false;
    }
    // キャラクタが移動していて，左右転換や矢印キーが押されなくなったら
    if (preDir != currentDir || dec)
    {
      this.Stop();
      preDir = currentDir;
    }

    // 現在の速度の絶対値を取る
    float speedx = Mathf.Abs(this.rigid2D.velocity.x);

    // 最大速度より現在の速度が遅かったら
    if (speedx < this.GetMaxWalkSpeed() )
    {
      this.rigid2D.AddForce(
          transform.right * key * this.GetWalkForce() );
    }

  }

  // x軸方向の速度を0にする．y軸方向の速度は変えない．
  private void Stop()
  {
    this.rigid2D.velocity = new Vector2(0, this.rigid2D.velocity.y);
  }

}

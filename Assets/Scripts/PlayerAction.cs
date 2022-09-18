using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    int h;
    int v;
    bool isHorizontalMove;
    Rigidbody2D rigid;

    Animator ani;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h=Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        v=Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        if(Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Vertical")){
            isHorizontalMove=true;
            ani.SetInteger("HorRaw",h);
        }
        else if(Input.GetButtonDown("Vertical") || Input.GetButtonUp("Horizontal")){
            isHorizontalMove=false;
            ani.SetInteger("VerRaw",v);
        }
        else{
            ani.SetInteger("HorRaw",0);
            ani.SetInteger("VerRaw",0);
        }
 

    
      
    }
    void FixedUpdate() {
        Vector2 moveVec = isHorizontalMove? new Vector2(h*2,0):new Vector2(0,v*2);
        rigid.velocity=moveVec;
    }
}

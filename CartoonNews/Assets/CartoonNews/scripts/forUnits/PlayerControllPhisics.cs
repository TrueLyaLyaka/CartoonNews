using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllPhisics : MonoBehaviour {
    public enum FacedDirection {FaceLeft=-1,FaceRight=1 };
    public FacedDirection Facing=FacedDirection.FaceRight;

    private Transform ThisTransform = null;
    private Rigidbody2D ThisBody = null;
    public float MaxSpeed = 10f;
    public string HorzAxis = "Horizontal";
    public string JumpButton = "Jump";
    public float JumpPower = 200f;
    private bool CanJump = true;
    public float JumpTimeOut = 0.5f;
    private float speedLimit= 3f;
    private float realSpeedX;

    public CircleCollider2D FeetCollider = null;
    public bool isGrounded = false;
    public LayerMask GroundLayaer;

    private Animator takeAnimator = null;
    private int MotionVal = Animator.StringToHash("Motion");   


	// Use this for initialization
	void Awake () {
        GetComponent<Rigidbody2D>().freezeRotation = true; // for dontforget to friz rotate Z
        ThisTransform = GetComponent<Transform>();
        ThisBody=GetComponent<Rigidbody2D>();
        takeAnimator = GetComponentInChildren<Animator>();        
	}
     
	// Update is called once per frame
	void FixedUpdate () 
    {
        //phisicsMove();
        noPhisicsMove();
	}

    #region phisicsMoove
    private bool GetGrounded()
    {
        Vector2 CircleCenter=new Vector2(ThisTransform.position.x,ThisTransform.position.y)+FeetCollider.offset;
        Collider2D[] HitColliders=Physics2D.OverlapCircleAll(CircleCenter,FeetCollider.radius,GroundLayaer);
        if (HitColliders.Length>0) return true;
        return false;
    }
    
    private void FlipDir()
    {
        Facing = (FacedDirection)((int)Facing * -1f);
        Vector3 LocalScale = ThisTransform.localScale;
        LocalScale.x *= -1f;
        ThisTransform.localScale = LocalScale;
    }
    private void Jump()
    {
        if (!isGrounded || !CanJump) return;

        ThisBody.AddForce(Vector2.up * JumpPower);
        CanJump = false;
        Invoke("ActivateJump", JumpTimeOut);
        takeAnimator.SetTrigger("jump");
    }
    private void ActivateJump()
    {
        CanJump = true;
    }
    void phisicsMove()
    {
        isGrounded = GetGrounded();
        float Horz = CrossPlatformInputManager.GetAxis(HorzAxis);
        if (gameObject.tag!="dead")
        {
            ThisBody.AddForce(Vector2.right * Horz * MaxSpeed); // moving 
            realSpeedX=ThisBody.velocity.x;                     // damping -----
            if (realSpeedX>=speedLimit || realSpeedX <=-speedLimit)
            {
                ThisBody.AddForce(Vector2.right * Horz*(-MaxSpeed));
            }                                                   // -------------

            if (CrossPlatformInputManager.GetButton(JumpButton))
            {              
                Jump();            
            }         

            ThisBody.velocity = new Vector2(Mathf.Clamp(ThisBody.velocity.x,-MaxSpeed,MaxSpeed),
                Mathf.Clamp(ThisBody.velocity.y,-Mathf.Infinity,
                    JumpPower));

            if (Horz < 0f && Facing != FacedDirection.FaceLeft || 
                Horz > 0f && Facing != FacedDirection.FaceRight)
            {
                FlipDir();
            }
        }
        takeAnimator.SetFloat(MotionVal,Mathf.Abs(Horz), 0.1f, Time.deltaTime);  
    }
    #endregion

    #region noPhisicsMove
    void noPhisicsMove()
    {
        isGrounded = GetGrounded();
        float Horz = CrossPlatformInputManager.GetAxis(HorzAxis);

        if (gameObject.tag!="dead")
        {
           
            if (Horz!=0)
            {              
                if (Horz>0)
                    ThisTransform.position +=ThisTransform.right* speedLimit * Time.deltaTime;
                if (Horz<0)
                    ThisTransform.position -=ThisTransform.right* speedLimit * Time.deltaTime;
            } 

            if (Horz < 0f && Facing != FacedDirection.FaceLeft || 
                Horz > 0f && Facing != FacedDirection.FaceRight)
            {
                FlipDir();
            }

            if (CrossPlatformInputManager.GetButton(JumpButton))
            {              
                Jump();            
            }    
            ThisBody.velocity = new Vector2(Mathf.Clamp(ThisBody.velocity.x,-MaxSpeed,MaxSpeed),
                Mathf.Clamp(ThisBody.velocity.y,-Mathf.Infinity,JumpPower));
        }
        takeAnimator.SetFloat (MotionVal, Mathf.Abs(Horz), 0.1f, Time.deltaTime*4);
    }
    #endregion
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private float _maxSpeed = 3.0f;
    private Vector2 _input;
    private int _inBossBattle;

    bool facingLeft = false;
    bool facingUp = false;
    bool isMoving = false;
    public Vector2 lastMotionVector;
   
    public void Awake()
    {
        _inBossBattle = PlayerData.instance.getIsInBossBattle() ? 0 : 1 ;
    }

    public void Move(InputAction.CallbackContext context) =>
        _input =  context.ReadValue<Vector2>();
    private void Update() 
    {
        float maxx;
        var velocity = new Vector3(_input.x, _input.y * _inBossBattle, 0.0f) * _maxSpeed;
        if (Mathf.Abs(_input.x) > Mathf.Abs(_input.y * _inBossBattle))
        {
            maxx = Mathf.Abs(_input.x);
        }
        else
        {
            maxx = Mathf.Abs(_input.y * _inBossBattle);
        }
        animator.SetFloat("Speed", maxx);

        if (_input.x != 0 || _input.y != 0)
        {
            lastMotionVector = new Vector2(
                _input.x,
                _input.y
                ).normalized;

            animator.SetFloat("lastHorizontal", lastMotionVector.x);
            animator.SetFloat("lastVertical", lastMotionVector.y);
        }


        /*        pentru muzica
         *        if (maxx > 0)
                    isMoving = true;
                else
                    isMoving = false;
                if (isMoving)
                {
                    if (!audioSrc.isPlaying)
                        audioSrc.Play();
                }
                else
                    audioSrc.Stop();*/

    }

    void FixedUpdate()
    {
        if (_input.y * _inBossBattle > 0)
        {
            animator.SetInteger("Direction", 2);
            if (!facingUp)
            { facingUp = !facingUp; }

        }
        if (_input.y * _inBossBattle < 0)
        {
            animator.SetInteger("Direction", 0);
            if (facingUp)
            { facingUp = !facingUp; }

        }
        if (_input.x != 0 )
        {
            animator.SetInteger("Direction", 1);
        }
        if (_input.x > 0 && facingLeft)
        {
            Flip();
        }
        if (_input.x < 0 && !facingLeft)
        {
            Flip();
        }

    }

    void Flip()
    {
        
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }
}

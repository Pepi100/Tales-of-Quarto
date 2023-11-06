using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed = 3.0f;
    private Vector2 _input;

    public void Move(InputAction.CallbackContext context) =>
        _input =  context.ReadValue<Vector2>();
    private void Update() {
        var velocity = new Vector3(_input.x, _input.y, 0.0f) * _maxSpeed;
        //transform.position = new Vector3()(_input.x, _input.y,  transform.position.z)
        transform.position += velocity * Time.deltaTime;
    }
}

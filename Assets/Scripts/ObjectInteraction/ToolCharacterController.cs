using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Interaction.ToolHit;
using Inventory.Model;

public class ToolCharacterController : MonoBehaviour
{
    CharacterMovement character;
    AgentWeapon agentWeapon;
    Rigidbody2D rgdb2d;
    [SerializeField] private float _offsetDistance = 1.0f;
    [SerializeField] private float _sizeOfInteractableArea = 1.2f;
    private float _coolDown = 0.7f;
    private float _lastShotTime = 0.0f;


    private void Awake()
    {
        character = GetComponent<CharacterMovement>();
        rgdb2d = GetComponent<Rigidbody2D>();
        agentWeapon = GetComponent<AgentWeapon>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {

        Debug.Log("In UseTool");
        Vector2 position = rgdb2d.position + character.lastMotionVector * _offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, _sizeOfInteractableArea);

        EquippableItemSO tool = agentWeapon.getWeapon();

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                if(Time.time - _lastShotTime >= _coolDown)
                {
                    Debug.Log("Register hit");
                    _lastShotTime = Time.time;
                    hit.Hit(tool);
                }
                break;
            }
        }
    }
}

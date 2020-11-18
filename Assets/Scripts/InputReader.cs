using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public Character character;
    void Update()
    {
        character.Move(Vector2.right * Input.GetAxis("Horizontal"));

        if(Input.GetKeyDown("w")) {
            character.Jump();
        }
        if(Input.GetKeyDown("s")) {
            character.Duck();
        }
        if(Input.GetKeyUp("s")) {
            character.GetUp();
        }

        if(Input.GetKeyDown("t")) {
            character.TakeDamage(20);
        }

    }
}

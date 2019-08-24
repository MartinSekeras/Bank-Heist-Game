using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private Rigidbody2D rb;
    bool aPressed = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //Gets components for animaor that rotates the player sprite depending on key pressed.
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Uses horizontal axis to move the player to right.
        if(Input.GetAxisRaw("Horizontal") > 0.5f) {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0f));
        }
        //Uses horizontal axis to move the player to left.
        if(Input.GetAxisRaw("Horizontal") < -0.5f) {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0f));
        }
        //Uses vertical axis to move player down.
        if (Input.GetAxisRaw("Vertical") > 0.5f) {
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * speed));
        }
        //Uses vertical axis to move player up.
        if(Input.GetAxisRaw("Vertical") < -0.5f) {
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * speed));
        }
        //Uses the input to compare it to animator presets. Animator preset is setup to trigger if axis is less than -0.5f or more then 0.5f. (It's 1f or -1f all the time, 0f if idle.)
        animator.SetFloat("X", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Y", Input.GetAxisRaw("Vertical"));
    }
}

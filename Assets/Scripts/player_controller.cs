using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float move_Speed;
    
    private SpriteRenderer player_sprite;
    private Animator anim;
    private Rigidbody2D player_rigid;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        player_sprite = GetComponent<SpriteRenderer>();
        player_rigid = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        float x_axis_input = Input.GetAxisRaw("Horizontal");
        float y_axis_input = Input.GetAxisRaw("Vertical");

        // control the facing of the characters

        if (x_axis_input != 0)
        {
            if (x_axis_input > 0.5f && (player_sprite.flipX == true)) // if the direction is to the right and is facing to the left
            {
                player_sprite.flipX = false;    //flip back
            }
            else if (x_axis_input < 0.5f && (player_sprite.flipX == false))
            {

                player_sprite.flipX = true;
            }
        }
        float move_horizontal = x_axis_input * move_Speed; //* Time.deltaTime;
        float move_vertical = y_axis_input * move_Speed; //* Time.deltaTime; 

        //transform.Translate(new Vector3(move_horizontal, move_vertical, 0f));
        

        player_rigid.velocity = new Vector2(move_horizontal, move_vertical); 


        anim.SetFloat("MoveX", x_axis_input);
        anim.SetFloat("MoveY", y_axis_input);
    }
}

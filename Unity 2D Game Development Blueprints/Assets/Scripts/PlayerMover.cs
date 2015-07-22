using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{

    // The speed by which the player will move
    public float speed = 10.0f;
    // Determine the current direction of the player
    int curDrection = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal axis
        // By default they are mapped to the arrow keys
        // The value is in the range -1 to 1
        // Make it move per seconds instead of frames
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //Change direction if needed
        if (translation > 0)
        {
            ChangeDirection(1);
        }
        else if (translation < 0)
        {
            ChangeDirection(-1);
        }
        // Move along the object's x-axis within the floor bounds
        if (transform.position.x + translation < 4 &&
           transform.position.x + translation > -4)
        {
            transform.Translate(Vector2.right * translation * curDrection);
        }
        // Switching between Idle and Walk in the animator
        if (Input.GetAxis("Horizontal") != 0)
        {
            GetComponent<Animator>().SetFloat("PlayerSpeed", speed);
        }
        else
        {
            GetComponent<Animator>().SetFloat("PlayerSpeed", 0);
        }
        // Switching sprites according to input
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GetComponent<Animator>().SetBool("Jump", !(GetComponent<Animator>().GetBool("Jump")));
        }
    }

    // Rotate the sprite to fit the current direction
    void ChangeDirection(int newDir)
    {
        if (newDir != curDrection)
        {
            // If the direction is right
            if (newDir == 1)
            {
                transform.Rotate(0, 180, 0);
                curDrection = 1;
            }
            // If the direction is left
            else if (newDir == -1)
            {
                transform.Rotate(0, -180, 0);
                curDrection = -1;
            }
        }
    }
}

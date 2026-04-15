using UnityEngine;
using UnityEngine.InputSystem;

public class FlipPrototype : MonoBehaviour
{
    public float flipNumber;
    public float jumpHeight = 0;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // lille 'b' ✅
    }

    void Update()
    {
        bool upWasPressed = Keyboard.current[Key.UpArrow].wasPressedThisFrame;
        bool downWasPressed = Keyboard.current[Key.DownArrow].wasPressedThisFrame;
        bool leftWasPressed = Keyboard.current[Key.LeftArrow].wasPressedThisFrame;
        bool rightWasPressed = Keyboard.current[Key.RightArrow].wasPressedThisFrame; // stort 'K' ✅
        
        if (upWasPressed)
        {
            rb.AddForce(0f, jumpHeight, 0f);
            rb.AddTorque(30f,0f,0f);
        }
            if (downWasPressed)
        {
            rb.AddForce(0f, jumpHeight, 0f);
            rb.AddTorque(-30f,0f,0f);
        }
            if (leftWasPressed)
        {
            rb.AddForce(0f, jumpHeight, 0f);
            rb.AddTorque(0f,0f,30f);
        }
            if (rightWasPressed)
        {
            rb.AddForce(0f, jumpHeight, 0f);
            rb.AddTorque(0f,0f,-30f);
        }
        
    }
}
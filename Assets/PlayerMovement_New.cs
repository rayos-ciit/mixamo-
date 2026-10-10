using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement_New : MonoBehaviour
{

    private Animator anim; //Reference for animator component
    private Vector3 movement;//Reference for our 2 axis movement (X,Y)
    private Rigidbody rb;
    public float moveSpeed;//Determines how fast our player is

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        movement = new Vector3(input.x, 0, input.y);
    }
    // Update is called once per frame
    void Update()
    {
        if (movement != Vector3.zero)
        {
            anim.SetFloat("MoveX", movement.x);
            anim.SetFloat("MoveY", movement.z);
        }
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}

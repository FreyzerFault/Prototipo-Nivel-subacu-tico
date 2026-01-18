using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction lookAction;
    
    public float speed = 1f;
    public float sensitivity = 1;
    public float maxFallSpeed = 2;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private Camera cam;
    private Rigidbody rb;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        rb  = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxFallSpeed;
    }
    
    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        lookInput = lookAction.ReadValue<Vector2>();
        
        Move();
        RotateView();
        
        // Underwater max fall-speed check
        // float fallSpeed = Mathf.Max(rb.linearVelocity.y, maxFallSpeed);
        // rb.linearVelocity = new Vector3(rb.linearVelocity.x, fallSpeed, rb.linearVelocity.z);
    }

    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
    }

    private void Move()
    {
        if (moveInput == Vector2.zero) return;

        Vector3 moveInput3D = new(moveInput.x, 0, moveInput.y);
        transform.Translate(moveInput3D * (speed * Time.deltaTime), Space.Self);
    }

    private void RotateView()
    {
        transform.Rotate(transform.up, lookInput.x * sensitivity * Time.deltaTime);
        
        cam.transform.Rotate(Vector3.right, -lookInput.y * sensitivity * Time.deltaTime);
        
        if (Vector3.SignedAngle(transform.forward, cam.transform.forward, transform.right) < -85)
        {
            Vector3 camRot = cam.transform.rotation.eulerAngles;
            cam.transform.rotation = Quaternion.Euler(-85, camRot.y, camRot.z);
        }
        if (Vector3.SignedAngle(transform.forward, cam.transform.forward, transform.right) > 85)
        {
            Vector3 camRot = cam.transform.rotation.eulerAngles;
            cam.transform.rotation = Quaternion.Euler(85, camRot.y, camRot.z);
        }
    }
}

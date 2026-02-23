using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Actions (dragfrom your Input Actions asset)")] //adds labels 
    [SerializeField] private InputActionReference p1Move;
    [SerializeField] private InputActionReference p2Move;
    

    [Header("Players")]
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;

    [Header("Picking Up Settings")]
    [SerializeField] private float grabDistance = 2.5f;
    [SerializeField] public Transform holdPosition;
    [SerializeField] private GameObject heldObject;


    [SerializeField] private float speed = 5f;
    
    private void Start()
    {
      
    }

    private void OnEnable()
    {
        p1Move.action.Enable();
        p2Move.action.Enable();

       
    }

    private void OnDisable()
    {
        p1Move.action.Disable();
        p2Move.action.Disable();

        
    }

    void Update()
    {
        var m1 = p1Move.action.ReadValue<Vector2>();
        var m2 = p2Move.action.ReadValue<Vector2>();



        if (p1) p1.position += new Vector3(m1.x, m1.y,0f) * speed * Time.deltaTime;
        if (p2) p2.position += new Vector3(m2.x, m2.y,0f) * speed * Time.deltaTime;


    }

    public void Grab()
    {
        Ray ray = new Ray(p1.position, p1.up);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, grabDistance))
        {
            if (hit.collider.CompareTag("Donut"))
            {
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody2D>();
                
            }
        }

    }
    
    
   
}


using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference p1Move;

    [SerializeField] private Transform p1;

    [SerializeField] private float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    private void OnEnable()
    {
        p1Move.action.Enable();
    }

    private void OnDisable()
    {
        p1Move.action.Disable();
    }

    private void Update()
    {
        var m1 = p1Move.action.ReadValue<Vector2>();

        if (p1) p1.position += new Vector3(m1.x, m1.y) * speed * Time.deltaTime;
    }
}

using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float steer = 30f;
    [SerializeField] public Transform target;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            return;
        }
        rb.velocity = transform.up * speed * Time.fixedDeltaTime;
        Vector2 direction = (target.position - transform.position).normalized;
        float rotationSteer = Vector3.Cross(transform.up, direction).z;
        rb.angularVelocity = rotationSteer * steer;
    }
}

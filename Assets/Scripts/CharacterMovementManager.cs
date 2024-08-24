using UnityEngine;

public class CharacterMovementManager : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private JoystickManager joystickManager;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var movementDirection = new Vector2(joystickManager.joystick.Direction.x, joystickManager.joystick.Direction.y);


        if (movementDirection != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg - 90f;

            float smoothedAngle = Mathf.LerpAngle(rb.rotation, targetAngle, 3f * Time.deltaTime);

            rb.rotation = smoothedAngle;

            rb.velocity = movementDirection.normalized * movementSpeed;
        }

        rb.velocity = rb.transform.up * movementSpeed;
    }
}

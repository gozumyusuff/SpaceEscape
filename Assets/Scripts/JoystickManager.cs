using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    public VariableJoystick joystick;
    public Canvas inputCanvas;

    private void Start()
    {
        EnableJoystickInput();
    }
    private void EnableJoystickInput()
    {
        inputCanvas.gameObject.SetActive(true);
    }
}

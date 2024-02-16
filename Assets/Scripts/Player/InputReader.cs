using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }
    public bool IsJump { get; private set; }
    
    public bool IsAccelerate { get; private set; }
    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        IsJump = Input.GetKeyDown(KeyCode.Space);
        IsAccelerate = Input.GetKey(KeyCode.LeftShift);
    }
}

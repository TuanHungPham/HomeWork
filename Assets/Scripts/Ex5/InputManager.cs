using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; set => instance = value; }

    #region public var
    public bool IsMovingInput { get => isMovingInput; private set => isMovingInput = value; }
    public bool IsJumpingInput { get => isJumpingInput; private set => isJumpingInput = value; }
    public bool IsShootingInput { get => isShootingInput; set => isShootingInput = value; }
    #endregion

    #region private var
    [SerializeField] private bool isMovingInput;
    [SerializeField] private bool isJumpingInput;
    [SerializeField] private bool isShootingInput;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Reset()
    {

    }

    private void Update()
    {
        CheckMovingInput();
        CheckJumpingInput();
        CheckShootingInput();
    }

    private void CheckShootingInput()
    {
        if (Input.GetMouseButton(0))
        {
            isShootingInput = true;
            return;
        }

        isShootingInput = false;
    }

    private void CheckMovingInput()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            IsMovingInput = false;
            return;
        }

        IsMovingInput = true;
    }

    private void CheckJumpingInput()
    {
        if (Input.GetAxis("Vertical") == 0)
        {
            IsJumpingInput = false;
            return;
        }

        IsJumpingInput = true;
    }
}

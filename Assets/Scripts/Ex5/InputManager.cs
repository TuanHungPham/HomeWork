using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; set => instance = value; }

    #region public var
    public bool IsMovingInput { get => isMovingInput; private set => isMovingInput = value; }
    public bool IsJumpingInput { get => isJumpingInput; private set => isJumpingInput = value; }
    #endregion

    #region private var
    [SerializeField] private bool isMovingInput;
    [SerializeField] private bool isJumpingInput;

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

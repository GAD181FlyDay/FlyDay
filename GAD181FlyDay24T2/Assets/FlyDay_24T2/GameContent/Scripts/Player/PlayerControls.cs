using UnityEngine;


/// <summary>
/// This is a unified script version of old player controllers.
/// </summary>

public class PlayerControls : MonoBehaviour
{
    #region Variables
    public Players selectedPlayer;
    public Animator playerAnimator;
    public Rigidbody playerRigidbody;
    public float moveSpeed = 0.4f, rotateSpeed = 1000f;
    public float jumpForce = 100f;

    #region Raycast Vars
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask groundMask;

    private bool _isGrounded;
    #endregion

    private float _walkingAnimationDelay = 0.25f;
    private float _walkingAnimationTimer;
    #endregion

    void FixedUpdate()
    {
        MovePlayer();
    }

    protected virtual void Update()
    {
        GroundCheck();
        WalkingAnimationSetter();
        WalkingAnimationDelayer();
        PlayerJumpCheckerAndExecuter();
    }

    #region Private Functions

    private void GroundCheck()
    {
        _isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundMask);
    }

    private void PlayerJumpCheckerAndExecuter()
    {
        if (Time.timeScale == 1)
        {
            KeyCode jumpKey = selectedPlayer == Players.one ? KeyCode.Space : KeyCode.RightControl;

            if (Input.GetKeyDown(jumpKey) && _isGrounded)
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnimator.SetBool("Jumping", true);
            }
            else
            {
                playerAnimator.SetBool("Jumping", false);
            }
        }
    }

    private void WalkingAnimationSetter()
    {
        if (playerAnimator != null)
        {
            bool walking = playerAnimator.GetBool("Walking");
        }
        else
        {
            Debug.Log("Won't play animations");
            return;
        }
    }

    private void WalkingAnimationDelayer()
    {
        bool isMoving = false;

        if (selectedPlayer == Players.one)
        {
            isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        }
        else if (selectedPlayer == Players.two)
        {
            isMoving = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow);
        }

        if (isMoving)
        {
            _walkingAnimationTimer = _walkingAnimationDelay;
            playerAnimator.SetBool("Walking", true);
        }
        else
        {
            if (_walkingAnimationTimer > 0)
            {
                _walkingAnimationTimer -= Time.deltaTime;
            }
            else
            {
                playerAnimator.SetBool("Walking", false);
            }
        }
    }

    private void MovePlayer()
    {
        float horizontal = 0;
        float vertical = 0;

        if (selectedPlayer == Players.one)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
        else if (selectedPlayer == Players.two)
        {
            horizontal = Input.GetAxis("Horizontal1");
            vertical = Input.GetAxis("Vertical1");
        }

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize();

        if (movement != Vector3.zero)
        {
            playerRigidbody.MovePosition(playerRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
            Quaternion rotateQuat = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateQuat, rotateSpeed * Time.deltaTime);
        }
        else
        {
            playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y, 0);
        }
    }

    #endregion
}

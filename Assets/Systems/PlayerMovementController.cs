using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput;

   private Rigidbody2D playerRb;

    [SerializeField] private Animator playerAnimController;



    // Store Animator references using a hash for better performance
    private int MoveInputXHash = Animator.StringToHash("MoveInputX");
    private int MoveInputYHash = Animator.StringToHash("MoveInputY");
    private int IsMovingHash = Animator.StringToHash("IsMoving");

    private int LastMoveXHash = Animator.StringToHash("LastMoveX");
    private int LastMoveYHash = Animator.StringToHash("LastMoveY");


    public bool moveEnabled = true;





    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        if(playerRb == null) Debug.LogError("Rigidbody2D component not found on the player object.");  
        
        playerAnimController = GetComponentInChildren<Animator>();
    }


    private void Update()
    {  
        HandlePlayerAnimation();


    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();       
    }

    private void LateUpdate()
    {   
    
    
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

    }

    private void HandlePlayerMovement()
    {
        // Only run movement if movement is enabled.
        if (moveEnabled == false) return;

        playerRb.MovePosition(playerRb.position + moveInput * moveSpeed * Time.fixedDeltaTime);  
    }

    private void HandlePlayerAnimation()
    {
        // cancel out of animation if movement is disabled
        if (moveEnabled == false)
        {
            playerAnimController.SetBool(IsMovingHash, false);
            return;
        }
            
     

        if (moveInput != Vector2.zero)
        {
            // Update the animator parameters based on the current movement input
            playerAnimController.SetFloat(MoveInputXHash, moveInput.x);
            playerAnimController.SetFloat(MoveInputYHash, moveInput.y);  
            playerAnimController.SetBool(IsMovingHash, true);

            //Sets the idle to the last direction moved
            playerAnimController.SetFloat(LastMoveXHash, moveInput.x);
            playerAnimController.SetFloat(LastMoveYHash, moveInput.y);
        }
        else
        {
            playerAnimController.SetBool(IsMovingHash, false);
        }
    }



}

















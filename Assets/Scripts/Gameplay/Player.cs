using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    
    //Data
    public float speed = 5.0f;
    public float rotationSpeed = 120.0f;

    //prefab
    public GameObject seedPrefab;
    public Parcel hoveredParcel;

    public ScoreManager scoreManager;

    //InputAction
    public InputActionReference inputCreateSeedReference;
    public InputActionReference inputGetVegetableReference;
    public InputActionReference inputMoveActionReference;

    private void FixedUpdate() 
    {
        MovementUpdate();
    }

    private void OnEnable()
    {
        inputMoveActionReference.action.Enable();
        
        inputCreateSeedReference.action.Enable();
        inputCreateSeedReference.action.performed += CreateSeed;
        
        inputGetVegetableReference.action.Enable();
        inputGetVegetableReference.action.performed += PickVegetable;
        
    }

    private void OnDisable()
    {
        inputCreateSeedReference.action.performed -= CreateSeed;
        inputCreateSeedReference.action.Disable();
        
        inputGetVegetableReference.action.performed -= PickVegetable;
        inputGetVegetableReference.action.Disable();
        
        inputMoveActionReference.action.Disable();
    }

    private void MovementUpdate()
    {
        Vector2 moveInput = inputMoveActionReference.action.ReadValue<Vector2>();

        // Move in facing direction 
        Vector3 movement = transform.forward * (moveInput.y * speed * Time.fixedDeltaTime);
        transform.Translate(movement, Space.World);

        // Y-axis rotation (invert when going backwards)
        float turnDirection = moveInput.x;
        if (moveInput.y < 0) turnDirection = -turnDirection;
        float turn = turnDirection * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        transform.Rotate(0, turnRotation.eulerAngles.y, 0);
    }


    private void CreateSeed(InputAction.CallbackContext ctx)
    {
        Vector3 seedPosition = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        Instantiate(seedPrefab, seedPosition, Quaternion.identity);
    }
    
    private void PickVegetable(InputAction.CallbackContext ctx)
    {
        scoreManager.AddPointToScore(hoveredParcel != null ? hoveredParcel.Harvest() : 0);
    }
}
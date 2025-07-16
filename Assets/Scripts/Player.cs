using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement/Player Settings")]
    [SerializeField] float gravityForce = -20f; // Valor negativo fuerte
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpHeight = 0.5f; // Altura máxima del salto en metros
    private float verticalVelocity;
    private Vector2 movementInput;
    private Vector2 mousePosition;
    private Vector3 lookTarget;
    private CharacterController characterController;
    private bool justJumped = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (characterController.isGrounded)
        {
            if (verticalVelocity < 0 && !justJumped)
                verticalVelocity = -2f; // Valor negativo pequeño para mantener pegado al suelo
            justJumped = false;
        }
        else
        {
            verticalVelocity += gravityForce * Time.deltaTime;
        }

        // Limitar la velocidad vertical a un rango razonable
        verticalVelocity = Mathf.Clamp(verticalVelocity, -50f, 10f);

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        move = transform.TransformDirection(move); // Convierte a espacio local
        move *= movementSpeed * Time.deltaTime;
        Vector3 finalMovement = new Vector3(move.x, verticalVelocity * Time.deltaTime, move.z);

        characterController.Move(finalMovement);

        lookTarget.y = transform.position.y;
        transform.LookAt(lookTarget);

        // Debug: muestra la velocidad vertical en consola
        // Debug.Log($"verticalVelocity: {verticalVelocity}");
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // Método para girar el personaje con el mouse o stick derecho (plataformas 3D)
    private float rotationY = 0f;
    [SerializeField] float lookSensitivity = 2f;
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        rotationY += lookInput.x * lookSensitivity;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    // Método para top-down: el personaje mira hacia el mouse en el plano
    public void OnMouseLook(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float enter))
        {
            lookTarget = ray.GetPoint(enter);
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && characterController.isGrounded)
        {
            // Fórmula física para salto: v = sqrt(2 * h * -g)
            verticalVelocity = Mathf.Sqrt(2f * jumpHeight * -gravityForce);
            justJumped = true;
        }
    }
}

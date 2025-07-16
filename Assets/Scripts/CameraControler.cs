using UnityEngine;
using UnityEngine.InputSystem;
public class CameraControler : MonoBehaviour
{
    public Animator cameraAnimator;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform playerTransform; // Asigna el transform del personaje en el inspector
    private bool topDownView = true;

    void LateUpdate()
    {
        // Solo en modo plataforma, iguala la rotación Y de la cámara a la del personaje
        if (!topDownView && playerTransform != null)
        {
            Vector3 camEuler = transform.eulerAngles;
            camEuler.y = playerTransform.eulerAngles.y;
            transform.eulerAngles = camEuler;
        }
    }

    public void OnCameraToggle(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (topDownView)
        {
            Debug.Log("Switching to Platformer View");
            cameraAnimator.SetTrigger("Platform");
            playerInput.SwitchCurrentActionMap("Player Plataform");
        }
        else
        {
            Debug.Log("Switching to TopDown View");
            cameraAnimator.SetTrigger("TD");
            playerInput.SwitchCurrentActionMap("Player TopDown");
        }
        
        topDownView = !topDownView;
    }    
}

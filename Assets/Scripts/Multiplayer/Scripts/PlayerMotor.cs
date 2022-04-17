using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour
{
   private Vector3 velocity = Vector3.zero;
   private Rigidbody rb;
   private Vector3 rotation  = Vector3.zero;
   private Vector3 cameraRotaion = Vector3.zero;

    public Camera cam;


   void Start()
   {   
       rb = GetComponent<Rigidbody>();
   }

   public void Move(Vector3 _velocity)
   {
       velocity = _velocity;
   }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null){
            cam.transform.Rotate(-cameraRotaion);
        }
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void CameraRotate(Vector3 _cameraRotation)
    {
        cameraRotaion = _cameraRotation;
    }
}


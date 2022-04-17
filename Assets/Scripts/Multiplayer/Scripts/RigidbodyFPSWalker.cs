using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof(PlayerMotor))]

public class RigidbodyFPSWalker : MonoBehaviour
{
    
    [SerializeField]
    private float speed = 5f;
    
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;
    private Vector3 _velocity;
    private Vector3 _rotation;
    private Vector3 _cameraRotation;
    private Vector3 _newVelocity;
    private Vector3 _newRotation;
    private Vector3  _newCameraRotaion;

    private GameObject mainCamera;
    public PhotonView nameTag;
    public GameObject me;


    //Next Time Adding
    public int hlth = 100;
    
    void Awake(){
        nameTag.RPC("updateName",Photon.Pun.RpcTarget.AllBuffered,PhotonNetwork.NickName);
    }
    void Start()
    {   
        motor = GetComponent<PlayerMotor>();
    }
    void Update()
    {

            ProcessInputs();
            if(hlth<=0){
                playerDied();
            }

    }

    public void ProcessInputs()
    {
         //calculating movement
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        
        

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        _velocity  = (_moveHorizontal + _moveVertical).normalized * speed;
        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");

        _rotation =new Vector3(0f,_yRot,0f) * lookSensitivity;

        motor.Rotate(_rotation);

        //camera rotaion 
        float _xRot = Input.GetAxisRaw("Mouse Y");
 
        _cameraRotation =new Vector3(_xRot,0f,0f) * lookSensitivity;

        motor.CameraRotate(_cameraRotation);
    }

    void OnGUI(){
        GUI.Box(new Rect(10,10,100,30),"HP | " + hlth);
    }

    [PunRPC]
    public void applyDamage(int damge){
        hlth = hlth - damge;
        Debug.Log("Hit:"+hlth);
    }
    [PunRPC]
    public void playerDied(){
        PhotonNetwork.Destroy(me);
        PhotonNetwork.LoadLevel("Level100");
        PhotonNetwork.LeaveRoom();
    }
    
    
}

using UnityEngine;
using Photon.Pun;
public class AnimControl : MonoBehaviour
{
    // public Animator animationController;
    public Animation am;
    public AnimationClip soldierFire;
    public AnimationClip soldierIdle;
    public AnimationClip soldierWalk;
    public Rigidbody rb;

    public bool isTp = false;


    public PhotonView graphicsPV;
    public Animation graphicsAM;
    // void Start(){
    //     animationController = GetComponent<Animator>();
    // }

  
    void Update()
    {   
        // animationController.SetFloat("speed",rb.velocity.magnitude * 100);
        if(Input.GetButtonDown("Fire1")){
            if(isTp){
                graphicsPV.RPC("playAnimPV",RpcTarget.AllBuffered,soldierFire.name);
                Debug.Log("FireWorks");
            }
            else{
                playAnimation(soldierFire.name);
            }
        }
        if(rb.velocity.magnitude * 1000 >= 0.01){
            if(isTp){
                graphicsPV.RPC("playAnimPV",RpcTarget.AllBuffered,soldierWalk.name);
            }
            else{
                playAnimation(soldierFire.name);
            }
        }
        else{
            if(isTp){
                graphicsPV.RPC("playAnimPV",RpcTarget.AllBuffered,soldierIdle.name);
            }
            else{
                playAnimation(soldierFire.name);
            }
        }
   
    }

    public void playAnimation(string name){
        am.CrossFade(name);
    }
    [PunRPC]
    public void playAnimPV(string name){
            graphicsAM.Play(name);
    }
}

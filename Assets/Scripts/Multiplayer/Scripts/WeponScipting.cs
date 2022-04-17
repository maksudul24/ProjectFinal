using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class WeponScipting : MonoBehaviour
{   
    public Camera fpscam;
    public GameObject hitPar;

    public Animation am;
    public AnimationClip shootanimation;

     public Animator animationController;
    public int damge = 30;
    public int range = 100;
    
    public int ammo = 10;
    public int clipsize = 10;
    public int clipcount = 5;
    
    // private Rect Menu11;
     void Start () {
        //  for loading the reload call in the center of the screen reltaive to display size
        //  int windowWidth = 200;
        //  int windowHeight = 200;
        //  int x = (Screen.width - windowWidth) / 2;
        //  int y = (Screen.height - windowWidth) / 2;
        //  Menu11 = new Rect(x,y,windowWidth,windowHeight);
        animationController = GetComponent<Animator>();
        animationController.SetBool("draw",true);
        
     }
    void Update(){
        if(Input.GetButtonDown("Fire1")){
            FireShot();
            Debug.Log("Firing");
        }
        if(Input.GetKeyDown(KeyCode.R)){
            ReloadCalling();
        }
    }
     public void FireShot(){
        // if(!am.IsPlaying(reloadAnimation.name)){
            if(ammo > 0){
                ammo = ammo - 1;
                //playing the animatin controller with the true or false value to make transition
                // am.Play(shootanimation.name);
                animationController.SetTrigger("shoot");
                RaycastHit hit;
                Ray ray = fpscam.ScreenPointToRay(new Vector3(Screen.width / 2,Screen.height / 2,0));
                if(Physics.Raycast(ray,out hit,range)){
                    if(hit.transform.tag == "Player"){
                        
                        hit.transform.GetComponent<PhotonView>().RPC("applyDamage",RpcTarget.AllBuffered,damge);
                    }
                    GameObject particleClone;
                    particleClone = PhotonNetwork.Instantiate(hitPar.name,hit.point,Quaternion.LookRotation(hit.normal),0) as GameObject;
                    Destroy(particleClone,2);
                    Debug.Log(hit.transform.name);

                }
            }
     }
     public void ReloadCalling()
     {  
        if(clipcount > 0 && ammo != clipsize){
            // am.CrossFade(reloadAnimation.name);
            animationController.SetTrigger("reload");
            ammo = clipsize;
            clipcount = clipcount - 1;
        }

     }
     void OnGUI(){
         GUI.Box(new Rect(110,10,100,30),"Ammo"+ammo+"/"+clipsize+"/"+clipcount);
     }
}

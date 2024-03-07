using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefs;
    [SerializeField] private Transform muzzleTrans;
    [SerializeField] private float bulletSpeed = 1000f;

    [SerializeField] AudioSource shootAudio;

    // Start is called before the first frame update
    void Start()
    
    {
        //Cursor.visible = false; 
        //if(Input.GeyKeyDown(KeyCode.LeftControl))
       // {
        //    Cursor.visible = true;
       // }

        Cursor.lockState = CursorLockMode.Confined;
        
        shootAudio = this.GetComponent<AudioSource>();
        // WWW audioLoader = new WWW("./Sound/Shoot_01.wav");
       // AudioClip selectClip = audioLoader.GetAudioClip(false, false, AudioType.WAV);
        //shootAudio.clip = selectClip;


    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootAudio.Play();
            GameObject instaBullet = Instantiate(bulletPrefs,
                                                muzzleTrans.position,
                                                muzzleTrans.rotation);

            Rigidbody bulletRigidbody = instaBullet.GetComponent<Rigidbody>();

            Vector3 force = muzzleTrans.forward * bulletSpeed;
            
            bulletRigidbody.AddForce(force);
        }
        
    }
}

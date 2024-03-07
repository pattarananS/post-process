using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankRot : MonoBehaviour
{
    [SerializeField] private Transform cam;
    private float rot;
    private float rotspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float yRotatiaon = cam.transform.eulerAngles.y;
       this.transform.eulerAngles = new Vector3(0f, yRotatiaon, 0f);
       TankShot();
    }

    void TankShot()
    {
        
    }
}

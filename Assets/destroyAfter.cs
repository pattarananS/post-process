using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfter : MonoBehaviour
{
    [SerializeField] GameObject bombParticle;
    [SerializeField] GameObject expAudio;

    public void Start()
    {

    }
        
    

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision) {

        
        
        GameObject InstaBomb = Instantiate(bombParticle,
                                            this.transform.position,
                                            this.transform.rotation);

        GameObject InstaSound = Instantiate(expAudio,
                                            this.transform.position,
                                            this.transform.rotation);
        
        
        
        Destroy(this.gameObject);

        
        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public GameObject Particle;
    float EnemyLife = 5;
    public movement mv;
    public bool ss;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 6 && mv.AlreadyAttacked){
            Instantiate(Particle,new Vector3(other.transform.position.x,transform.position.y,other.transform.position.z),transform.rotation);
            EnemyLife--;
            if(EnemyLife == 0){
                Destroy(other.gameObject);
                // Destroy(Particle);
            }
        }
    }
}

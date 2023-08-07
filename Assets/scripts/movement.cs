using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private AudioSource ac;
    public bool CanAttack = true;
    public CharacterController PlayerC;
    public AudioClip SwordAttack;
    public AudioClip PlayerShout; 
    public AudioClip Dying;
    public bool AlreadyAttacked = false; 
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 Move = new Vector3(x,0,z);
        // rb.velocity = Move* Time.deltaTime *150;
        PlayerC.Move(Move*Time.deltaTime*4);
        anim.SetFloat("Xvel",x);
        anim.SetFloat("Zvel",z);
        if(CanAttack && Input.GetMouseButtonDown(0)){
            ac.PlayOneShot(SwordAttack);
            ac.PlayOneShot(PlayerShout);
            ac.PlayOneShot(Dying);
            AlreadyAttacked = true;
            CanAttack = false;
            anim.SetTrigger("attack");
            StartCoroutine(AttackCoolDown());
        }
        IEnumerator AttackCoolDown(){
            StartCoroutine(AttackCoolDow());
            yield return new WaitForSeconds(3);
            CanAttack = true;
        }
        IEnumerator AttackCoolDow(){
            yield return new WaitForSeconds(1);
            AlreadyAttacked = false;
        }
        

    }
}

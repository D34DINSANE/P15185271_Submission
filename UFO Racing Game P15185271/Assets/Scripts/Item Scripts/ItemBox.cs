using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespace Items;
public class ItemBox : MonoBehaviour
{

    
    public float multiplier = 1.5f;
    float Timer = 0f;

    [SerializeField] float rotateSpeed;
    [SerializeField] float respawnTime;

    // Update is called once per frame, rotating the boxes
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
    // Hides the object 
    private void Hide()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;

    }
    // Reveals the object
    private void Show()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<Renderer>().enabled = true;
    }
    // On collision with tagged objects start routines
    void OnTriggerEnter(Collider coll)    
    {

        if (coll.gameObject.tag == "Player")
        {
    
            StartCoroutine(speedBoost());
            Hide();
            StartCoroutine(WaitForRespawn());
        }

        if (coll.gameObject.tag == "AI")
        {
        
          //  boost.speed *= multiplier;
            StartCoroutine(speedBoostAI());
            Hide();
            StartCoroutine(WaitForRespawn());
        }
    }

    // Temporary speed boost code
    IEnumerator speedBoost()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Ship_Movement boost = player.GetComponent<Ship_Movement>();
        boost.speed += 50;
        yield return new WaitForSeconds(4);
        revertSpeed();
    }
    // Issues with AI speed boost implementation
    IEnumerator speedBoostAI()
    {        
         GameObject ai = GameObject.FindGameObjectWithTag("AI");
         NodeFollow boost = ai.GetComponent<NodeFollow>();
         boost.speed += 50;
         yield return new WaitForSeconds(2);
        revertSpeedAI();   
    }

    void revertSpeedAI()
    {
        GameObject ai = GameObject.FindGameObjectWithTag("AI");
        NodeFollow boost = ai.GetComponent<NodeFollow>();
        boost.speed = boost.Ospeed;
    }

    void revertSpeed()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Ship_Movement boost = player.GetComponent<Ship_Movement>();
        boost.speed = boost.Ospeed;
    }
 
    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        Show();
    }
}

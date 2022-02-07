using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    public GameObject fruitCutPrefab;
    public float explodePower = 5f;
    private GameManager gm;

    public void CreateSlice()
    {
        GameObject inst = Instantiate(fruitCutPrefab, transform.position, transform.rotation);
        
        Rigidbody[] rbonSlice = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigid in rbonSlice)
        {
            rigid.transform.rotation = Random.rotation;
            rigid.AddExplosionForce(Random.Range(300, 600), transform.position, explodePower);
        }

        gm.ScoreUpdate(3);
        gm.AudioSound();

        Destroy(gameObject);
        Destroy(inst, 5f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        
        if(!b)
        {
            return;
        }

        CreateSlice();
    }
}

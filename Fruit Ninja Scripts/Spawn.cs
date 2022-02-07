using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject apple;
    public GameObject orange;
    public GameObject cheese;
    public GameObject bomb;
    public Transform[] spawnPoint;
    public float minWait = 0.3f;
    public float maxWait = 1f;
    public float minF = 10f;
    public float maxF = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPoint[Random.Range(0, spawnPoint.Length)];
            
            float ran = Random.value;

            if (ran < 0.2)
            {
                GameObject g = Instantiate(apple, t.transform.position, t.transform.rotation);
                g.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minF, maxF), ForceMode2D.Impulse);
                Destroy(g, 5f);
            }
            else if (ran < 0.5)
            {
                GameObject g = Instantiate(orange, t.transform.position, t.transform.rotation);
                g.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minF, maxF), ForceMode2D.Impulse);
                Destroy(g, 5f);
            }
            else if (ran < 0.7)
            {
                GameObject g = Instantiate(cheese, t.transform.position, t.transform.rotation);
                g.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minF, maxF), ForceMode2D.Impulse);
                Destroy(g, 5f);
            }
            else if (ran < 1.0)
            {
                GameObject g = Instantiate(bomb, t.transform.position, t.transform.rotation);
                g.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minF, maxF), ForceMode2D.Impulse);
                Destroy(g, 5f);
            }
        }
    }
}

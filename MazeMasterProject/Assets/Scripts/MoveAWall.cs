using UnityEngine;
using System.Collections;

public class MoveAWall : MonoBehaviour
{
    public GameObject targetA;
    public GameObject targetB;
    public float speed = 0.1f;
    public float elapsedTime = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float weight = Mathf.Cos(elapsedTime * speed * 2 * Mathf.PI) * 0.5f + 0.5f;
        transform.position = targetA.transform.position * weight + targetB.transform.position * (1 - weight);
        elapsedTime += Time.deltaTime;
    }
}
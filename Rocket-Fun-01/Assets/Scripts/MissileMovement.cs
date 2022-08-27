using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public ParticleSystem thrust;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.Rotate(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.left * speed * Time.deltaTime);
        thrust.Play();
    }
}

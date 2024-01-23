using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;
    public float fly;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(rb.velocity.x, fly, rb.velocity.z));
            thisAnimation.Play();
        }
        if(transform.position.y >= 4.20f || transform.position.y <= -4.50f)
        {
            GameManager.thisManager.GameOver();
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            GameManager.thisManager.GameOver();
        }
    }
    public void OnTriggerEnter(Collider point)
    {
        if (point.gameObject.tag == "Point")
        {
            GameManager.thisManager.UpdateScore();
        }
    }
}

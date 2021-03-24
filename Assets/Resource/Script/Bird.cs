using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bird : MonoBehaviour
{
    public float jumpPower = 5f;
    public GameObject imageBird;
    public Vector3 lookDirection;
    public static Bird bird;
    void Awake()
    {
        bird = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.manager.end == false)
        {
            if (Input.GetMouseButtonDown(0) && this.transform.position.y < 5f)
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                this.GetComponent<Rigidbody>().AddForce(0, jumpPower, 0, ForceMode.VelocityChange);
                this.GetComponent<AudioSource>().Play();
            }
            if (GameManager.manager.ready == false)
            {
                lookDirection.z = this.GetComponent<Rigidbody>().velocity.y * 10f + 20f;
            }
            Quaternion R = Quaternion.Euler(lookDirection);
            imageBird.transform.rotation = Quaternion.RotateTowards(imageBird.transform.rotation, R, 5f);
        }
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Cactus" || target.tag == "Ground")
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, -3, 0);
            lookDirection = new Vector3(0, 0, -90f);
            GameManager.manager.GameOver();
        }
        else if (target.tag == "Goal" && GameManager.manager.end != true)
        {
            GameManager.manager.GetScore();
        }
        else if (target.tag == "Gem" && GameManager.manager.end != true)
        {
            for (int i = 0; i < 2; i++)
            {
                GameManager.manager.GetScore();
            }
            Destroy(target.gameObject);
        }
    }
}

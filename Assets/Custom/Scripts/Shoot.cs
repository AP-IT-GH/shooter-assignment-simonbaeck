using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public AudioClip audioClip;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    float timer = 10f;
    bool start = false;
    public float shootRate = 3f;
    public int ShootForce = 75;
    void Update()
    {
        float shoot = Input.GetAxis("Fire1");
        print(shoot);

        if (shoot == 1 && timer >= shootRate)//shoot{
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * ShootForce, ForceMode.VelocityChange);
            start = true;
            timer = 0f;

            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    //gameobject has audiosource
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {

                    //add audiosource to gameobject: dynamically create object with audiosource,it will remove itself
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }
        }

        if (start)
        {
            if (timer < shootRate)
                timer += Time.deltaTime;
            else
            {
                timer = shootRate;
                start = false;
            }

        }
    }
}

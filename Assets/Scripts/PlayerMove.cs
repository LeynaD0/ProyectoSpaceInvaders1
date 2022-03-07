using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public SpaceShipData data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameDataPersistent.instance.selectSpaceShip;
        speed = data.speed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;

        if(horizontal < 0 && transform.position.x > -250)
        {
            position.x = position.x + speed * horizontal;
            transform.position = position;
        }

        if (horizontal > 0 && transform.position.x < 250)
        {
            position.x = position.x + speed * horizontal;
            transform.position = position;
        }
    }

    public void Projectile()
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bulletSpeed;
    public Camera camera;
    public CharacterController controller;
    public float speed = 12f;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 3;

    bool isGrounded;
    
    public enum PlayerClass
    {
        Soldier, Trapper
    }
    
    public PlayerClass playerClass;

    public List<Weapon> weapons;

    public Transform primaryWeapon;
    public Transform secondaryWeapon;

    public GameObject activeGun;
    public GameObject bullet;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(move * speed* Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Select 1"))
        {
            activeGun = Instantiate(weapons[0].weaponObject, secondaryWeapon.transform.position, secondaryWeapon.transform.rotation);
            activeGun.transform.SetParent(secondaryWeapon.transform);
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireGun();
        }
    }

    void FireGunFail()
    {
        /*Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }*/

        //Bullet tempBullet = bullet.GetComponent<Bullet>();
        /*Weapon wep = activeGun.GetComponent<Weapon>();
        GameObject Temp_Bullet_Handler;
        Vector3 pos = new Vector3(wep.transform.position.x, wep.transform.position.y, wep.transform.position.z);
        Temp_Bullet_Handler = Instantiate(bullet, pos, wep.bulletSpawn.transform.rotation) as GameObject;

        //Temp_Bullet_Handler.transform.Rotate(wep.transform.rotation.x, wep.transform.rotation.y, wep.transform.rotation.z);

        Rigidbody Temp_RigidBody = Temp_Bullet_Handler.GetComponent<Rigidbody>();
        Temp_RigidBody.AddForce(transform.forward * bulletSpeed);

        /*GameObject temp_bullet = Instantiate(bullet);

        Physics.IgnoreCollision(temp_bullet.GetComponent<Collider>(), activeGun.GetComponent<Weapon>().bulletSpawn.GetComponentInParent<Collider>());
        activeGun.GetComponent<Weapon>().bulletSpawn.transform.rotation = activeGun.transform.rotation;
        temp_bullet.transform.position = activeGun.GetComponent<Weapon>().bulletSpawn.transform.position;

        Vector3 rotation = temp_bullet.transform.rotation.eulerAngles;

        temp_bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        Rigidbody Temp_RigidBody = temp_bullet.GetComponent<Rigidbody>();
        Temp_RigidBody.AddForce(transform.forward * temp_bullet.GetComponent<Bullet>().bulletSpeed, ForceMode.Impulse);*/


    }

    void FireGun()
    {

    }
}

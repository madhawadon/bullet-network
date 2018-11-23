using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    [Range(0f, 1000f)] public float speed = 1f;
    [Range(.5f, 1f)] public float frameDrag = 1f;
    public GameObject bulletObject;
    [Range(0f, 1000f)] public float bulletSpeed = 1f;

    private Rigidbody _body;

	// Use this for initialization
	void Awake() {
        _body = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() {
        Vector3 delta = Vector3.zero;
        delta.x = Input.GetAxis("Horizontal");
        delta.z = Input.GetAxis("Vertical");

        _body.AddForce(delta * speed);
        _body.velocity *= frameDrag;

        // Look where you're headed
        if (_body.velocity.magnitude > 0.1f) { this.transform.rotation = Quaternion.LookRotation(_body.velocity); }
	}

    void FixedUpdate() { if (Input.GetButtonDown("Jump")) { ShootBullet(); } }

    void ShootBullet() {

        // Spawn bullet in front of player
        var bullet = Instantiate(bulletObject, this.transform);
        bullet.transform.SetParent(null);
        bullet.transform.localPosition += this.transform.forward;
        bullet.GetComponent<Rigidbody>().velocity = this.transform.forward * bulletSpeed;
    }
}

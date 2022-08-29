using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    [SerializeField] KeyCode keyone;
    [SerializeField] KeyCode keytwo;
    [SerializeField] Vector3 moveDirection;
    public GameObject FinishText;
    public GameObject player;
    public GameObject Line;
    public float jumpSpeed;
    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if(Input.GetKey(keyone)) {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }

        if (Input.GetKey(keytwo)) {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }

        if (Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(this.CompareTag("Player") && other.CompareTag("Finish")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(this.CompareTag("Player") && other.CompareTag("FinishGame"))
        {
            FinishText.SetActive(true);
        }
        if(other.CompareTag("Jump"))
        {
            rb.AddForce(0, 5, 0, ForceMode.Impulse);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

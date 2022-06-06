using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidaGol : MonoBehaviour
{
    private Rigidbody rbody;
    private bool grounded;
    public string Piso;
    public bool TemTarget;

    private GameObject player1;
    private GameObject player2;

    public TextMeshProUGUI placar_P1_GUI;
    public TextMeshProUGUI placar_P2_GUI;

    public GameObject bola;

    public Material floorMaterial;
    private MeshRenderer mrend;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();  // Get the rigidbody component  
        Piso = "";

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        mrend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();
    }

    void IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            grounded = true;
            Piso = hit.transform.name;
        }
        else {
            grounded = false;
        }        
    }

    void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject.name == "GolP1")
        {   
            player2.GetComponent<PlayerMovement>().placar += 1;
            placar_P2_GUI.text = player2.GetComponent<PlayerMovement>().placar.ToString();
        }
        else if (other.gameObject.name == "GolP2")
        {
            player1.GetComponent<PlayerMovement>().placar += 1;
            placar_P1_GUI.text = player1.GetComponent<PlayerMovement>().placar.ToString();
        }
        
        Instantiate(bola, new Vector3(0, 6, 0), Quaternion.identity);
        Destroy(this);
        mrend.material = floorMaterial;
    }
}

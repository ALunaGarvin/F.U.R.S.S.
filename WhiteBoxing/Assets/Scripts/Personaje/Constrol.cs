using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Constrol : MonoBehaviour
{

    public int vel, saltoFuerza, VelMax, velEscalera;
    private int Multiplicador = 200;
    private bool onFloor, space = false, onStair = false;
    public GameObject luzInstanciada;
    Rigidbody2D rb;
    public Camera camara;
    void Start()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detecta si está en el suelo o no
        if (onFloor == false)
        {
            if (collision.gameObject.layer == 8)
            {
                onFloor = true;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

            if (collision.gameObject.layer == 9)
            {
            onStair = true;
                if (space == true)
                {
                    Debug.Log("OLE");
                    Transform escalera = collision.gameObject.GetComponent<Escalera>().otroLado.transform;

                    EscaleraFuncion(escalera);
                }
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            onStair = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Controles();
        camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        //Ajusta la velocidad maxima
        if (rb.velocity.magnitude > VelMax)
        {
            rb.velocity = rb.velocity.normalized * VelMax;
        }
    }

    void Controles()
    {
        //Moverse izquierda derecha
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * vel * Multiplicador * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * vel * Multiplicador * Time.deltaTime);
        }

        if (onFloor == true) //Salto
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                space = true;
                if (onStair == false)
                {
                    rb.AddForce(Vector2.up * saltoFuerza * Multiplicador * Time.deltaTime);
                }
                onFloor = false;
            }
            else space = false;
        }

        //Raton controles

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 LightPosition = ray.origin + ray.direction;

            Instantiate(luzInstanciada, LightPosition, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x, m.y, transform.position.z);
            Vector3 p = camara.ScreenToWorldPoint(m);

            RaycastHit2D hit = new RaycastHit2D();
            Ray2D ray2D = new Ray2D(new Vector2(p.x, p.y), Vector3.down);
            hit = Physics2D.Raycast(new Vector2(p.x, p.y), Vector3.forward, 5.0f);

            if(hit.collider.tag == "Luz")
            {
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.tag == "SpotLight")
            {
                hit.collider.gameObject.GetComponent<SpotLightScript>().SpotLight = false;
                hit.collider.gameObject.GetComponent<SpotLightScript>().render.enabled = false;
            }

        }
    }

    void EscaleraFuncion(Transform destination)
    {
        Collider2D col = GetComponent<BoxCollider2D>();
        col.enabled = false;
        transform.position = destination.position;
        col.enabled = true;
        space = false;
    }
}


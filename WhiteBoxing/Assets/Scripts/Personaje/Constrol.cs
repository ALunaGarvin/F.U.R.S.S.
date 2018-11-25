using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Constrol : MonoBehaviour
{

    public int vel, saltoFuerza, VelMax, velEscalera;
    private int Multiplicador = 200;
    private bool onFloor, space = false, onStair = false, OnManta = false;
    public GameObject luzInstanciada;
    Rigidbody2D rb;
    public Collider2D col, col1;
    public SpriteRenderer spr;
    public Animator anim;
    public Camera camara;
    public Niveles niveles;
    public bool pierde = false, gana = false;
    void Start()
    {
        VelMax = 5;
        niveles = GameObject.FindGameObjectWithTag("Niveles").GetComponent<Niveles>();
        transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onFloor == false)
        {
            if (collision.gameObject.layer == 8)
            {
                onFloor = true;
            }
        }
        if (collision.gameObject.layer == 10)
        {
            Physics2D.IgnoreCollision(collision.collider, col);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
           /* Animator animMonje = GetComponent<Animator>();
            animMonje.SetBool("Agua", true);*/
            pierde = true;
            collision.gameObject.GetComponentInParent<Monje>().anim.SetBool("Agua", true);
            collision.gameObject.GetComponentInParent<Monje>().enabled = false;
            anim.SetBool("Muerte", true);
            Invoke("YouLose", 2);
        }
        if (collision.gameObject.layer == 12)
        {
            gana = true;
            Invoke("YouWin", 1);
        }
        if (collision.gameObject.layer == 9)
            {
            onStair = true;
                if (Input.GetKeyDown(KeyCode.W))
                {
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
       if(pierde != true) Controles();
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
        if (OnManta != true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * vel * Multiplicador * Time.deltaTime);
                spr.flipX = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * vel * Multiplicador * Time.deltaTime);
                spr.flipX = true;
            }

            if (onFloor == true) //Salto
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    anim.Play("salt");
                    space = true;
                    if (onStair == false)
                    {
                        rb.AddForce(Vector2.up * saltoFuerza * Multiplicador * Time.deltaTime);
                    }
                    onFloor = false;
                }
                else space = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Manta", true);
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            col.enabled = false;
            col1.enabled = false;
            OnManta = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnManta = false;
            anim.SetBool("Manta", false);
            col.enabled = true;
            col1.enabled = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        //Raton controles
        if(OnManta != true) { 
            if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("bolav2");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 LightPosition = ray.origin + ray.direction;

            Instantiate(luzInstanciada, LightPosition, Quaternion.identity);
        }
            if (Input.GetButtonDown("Fire2"))
            {
                anim.Play("bolav2");
                Vector3 m = Input.mousePosition;
                m = new Vector3(m.x, m.y, transform.position.z);
                Vector3 p = camara.ScreenToWorldPoint(m);

                RaycastHit2D hit = new RaycastHit2D();
                Ray2D ray2D = new Ray2D(new Vector2(p.x, p.y), Vector3.down);
                hit = Physics2D.Raycast(new Vector2(p.x, p.y), Vector3.forward, 5.0f);

                if (hit.collider.tag == "Luz")
                {
                    Destroy(hit.collider.gameObject);
                }
                if (hit.collider.tag == "SpotLight")
                {
                    hit.collider.gameObject.GetComponent<SpotLightScript>().SpotLight = false;
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("Fuego", true);
                }
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
    void YouLose()
    {
        niveles.botones.YouLose();
    }
    void YouWin()
    {
        niveles.botones.YouWin();
    }
}


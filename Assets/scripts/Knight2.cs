using System;
using System.Collections;
using UnityEngine;

public class Knight2 : MonoBehaviour
{
    static public float z = (float)-3.9798;
    static public int column = 3;
    static public int row = 3;
    static public int column2 = 1;
    static public int row2 = 1;
    private bool move = false;
    private Animator animator;
    public static bool start = false;
    public int maxHealth = 30;
    public int currentHealth;

    public HealthBar healthBar;

    public float distanceToMove = 0.5f;
    public float timeMove = 2.0f;
    private Vector3 startPosition;
    private Vector3 destination;
    private float startTime;
    public static int howManyMoves = 0;
    public static bool blockade = true;
    public new Collider2D collider;
    int id = 2;
    public static string tablica = "";
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = true;

        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        


    }
    void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDmg(5);
        }
        if (move)
        {

            float elapsedTime = Time.time - startTime;
            float journeyFraction = elapsedTime / timeMove;

            transform.position = Vector3.Lerp(startPosition, destination, journeyFraction);


        }
        Vector3 newPosition = transform.position;
        newPosition.z = z;
        transform.position = newPosition;
    }

    public void ColliderOff ()
    {
        collider.enabled = false;
    }
    public void ColliderOn()
    {
        collider.enabled = true;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<Movement>().Range(id, column, row);
        blockade = false;
    }

    public IEnumerator Movement()
    {
        for (int i = 0; i < howManyMoves; i++)
        {
            if (tablica[i] == '1')
            {
                //    Debug.Log("Up");
                z = (float)(z + 0.01);
                move = true;
                animator.SetTrigger("StartWalk1");
                startPosition = transform.position;
                destination = startPosition + new Vector3(0.85f, 0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");

            }
            else if (tablica[i] == '2')
            {
                z = (float)(z - 0.0001);
                //    Debug.Log("Right");
                move = true;
                animator.SetTrigger("StartWalk2");
                startPosition = transform.position;
                destination = startPosition + new Vector3(0.85f, -0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");

            }
            else if (tablica[i] == '3')
            {

                z = (float)(z + 0.0001);
                //   Debug.Log("Left");
                move = true;
                animator.SetTrigger("StarWalk3");
                startPosition = transform.position;
                destination = startPosition + new Vector3(-0.85f, 0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");

            }
            else if (tablica[i] == '4')
            {
                z = (float)(z - 0.01);
                //Debug.Log("Down");
                move = true;
                animator.SetTrigger("StartWalk4");
                startPosition = transform.position;
                destination = startPosition + new Vector3(-0.85f, -0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
            }

        }
        blockade = true;
        howManyMoves = 0;

    }
}

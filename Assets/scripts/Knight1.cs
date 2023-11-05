using System;
using System.Collections;
using UnityEngine;

public class Knight1 : MonoBehaviour
{
    public HealthBar healthBar;
    float z = -4;
    static public int column = 1;
    static public int row = 1;
    static public int column2 = 1;
    static public int row2 = 1;
    private bool move = false;
    private Animator animator;
    public static bool start=false;
    public static bool blockade = true;
    public float distanceToMove = 0.5f;
    public float timeMove = 2.0f;
    private Vector3 startPosition;
    private Vector3 destination;
    private float startTime;
   public static int howManyMoves = 0;
    public new Collider2D collider;
    int id = 1;
    public static string tablica="";
    public int maxHealth = 30;
    public int currentHealth;


    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = true;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
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
    public void ColliderOff()
    {
        collider.enabled = false;
    }
    public void ColliderOn()
    {
        collider.enabled = true;
    }
    private void OnMouseDown()
    {
        blockade = false;
        FindObjectOfType<Movement>().Range(id, column, row);
    }

   public  IEnumerator Movement()
    {
        for (int i = 0; i < howManyMoves; i++)
        {

            if (tablica[i] == '1')
            {
                //    Debug.Log("Up");
                z = (float)(z + 0.01);
                animator.SetTrigger("StartWalk1");
                move = true;
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
                animator.SetTrigger("StartWalk2");
                move = true;
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
                animator.SetTrigger("StarWalk3");
                Debug.Log("lewo");
                move = true;
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
                animator.SetTrigger("StartWalk4");
                move = true;

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

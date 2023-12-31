using System;
using System.Collections;
using UnityEngine;

public class Knight1 : MonoBehaviour
{
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


    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = true;

        animator = GetComponent<Animator>();

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
      //  animator.SetTrigger("Idle2");

        for (int i = 0; i < howManyMoves; i++)
        {

            if (tablica[i] == '1')
            {

                //animator.SetTrigger("Idle");
                //    Debug.Log("Up");
                z = (float)(z + 0.01);
              //  animator.SetTrigger("Idle2");
                animator.SetTrigger("StartWalk1");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(0.85f, 0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
             //   animator.SetTrigger("Idle1");

                //    animator.SetTrigger("Idle1");
                //  animator.SetTrigger("Idle3");

            }
            else if (tablica[i] == '2')
            {

                //  animator.SetTrigger("Idle");
                z = (float)(z - 0.0001);
                //    Debug.Log("Right");
               // animator.SetTrigger("Idle2");
                animator.SetTrigger("StartWalk2");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(0.85f, -0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
               // animator.SetTrigger("Idle22");


            }
            else if (tablica[i] == '3')
            {

                z = (float)(z + 0.0001);
                //   Debug.Log("Left");
                //   animator.SetTrigger("Idle2");
                animator.SetTrigger("StarWalk3");
                Debug.Log("lewo");
                move = true;
                startPosition = transform.position;
                destination = startPosition + new Vector3(-0.85f, 0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
              // animator.SetTrigger("Idle1");

                //   animator.SetTrigger("Idle3");
            }
            else if (tablica[i] == '4')
            {
                z = (float)(z - 0.01);
                //  animator.SetTrigger("Idle");
                //Debug.Log("Down");
              //  animator.SetTrigger("Idle2");
                animator.SetTrigger("StartWalk4");
                move = true;

                startPosition = transform.position;
                destination = startPosition + new Vector3(-0.85f, -0.45f, 0.0f);
                startTime = Time.time;
                yield return new WaitForSeconds(1.49f);
                move = false;
                animator.SetTrigger("Idle2");
            //     animator.SetTrigger("Idle4");
            }
            /*
            if (tablica[howManyMoves-1]=='1')
                animator.SetTrigger("Idle1");

            if (tablica[howManyMoves - 1] == '2')
                animator.SetTrigger("Idle22");

            if (tablica[howManyMoves - 1] == '3')
                animator.SetTrigger("Idle22");

            if (tablica[howManyMoves - 1] == '4')
                animator.SetTrigger("Idle4");
            */
        }
        blockade = true;


        howManyMoves = 0;

    }


}

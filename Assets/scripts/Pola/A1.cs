using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class P11 : MonoBehaviour, Pole
{


    private SpriteRenderer spriteRenderer;
    public Color kolor1 = Color.white;
    public Color kolor2 = Color.green;
    public Color kolor3 = Color.blue;
    public bool green { get; set; }
    public bool pole { get;  set; } 

    int kolumna = 1;
    int wiersz = 1;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pole = false;

    }

    void Update()
    {
        if (Knight1.column == kolumna && Knight1.row == wiersz || Knight2.column == kolumna && Knight2.row == wiersz)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            spriteRenderer.color = kolor3;


        }
        else if (spriteRenderer.color != kolor2)
        {
            GetComponent<BoxCollider2D>().enabled = true;

            spriteRenderer.color = kolor1;

        }
    }


    private void OnMouseDown()
    {
        if (pole)
        {
            FindObjectOfType<Movement>().Move(kolumna, wiersz);
        }


    }
    public void Kolor()
    {
        if (green)
        {
            spriteRenderer.color = kolor2;

        }
        else
        {
            pole = false;
            spriteRenderer.color = kolor1;

        }
    }
 

}

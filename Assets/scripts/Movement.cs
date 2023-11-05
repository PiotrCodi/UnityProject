using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    static public int column2 = 0;
    static public int row2 = 0;
    public static bool start = false;
    string test;
    int howManyMoves = 0;
    int pomcol;
    int pomrow;
    private DictionaryC klasaZDictionary;
    private Knight1 ruch;
    private Knight2 knight2;
    int id;
    int columnTemporary;
    int rowTemporary;
    string rycerz2;
    int k = 3;

    void Update()
    {
        if (Knight1.blockade && Knight2.blockade)
        {
            FindObjectOfType<Knight2>().ColliderOn();
            FindObjectOfType<Knight1>().ColliderOn();

        }
        else
        {
            FindObjectOfType<Knight2>().ColliderOff();
            FindObjectOfType<Knight1>().ColliderOff();
        }
    } 

    public void Range(int id2, int column, int row)
    {
        id = id2;
        columnTemporary = column;
        rowTemporary = row;
        start = true;

        klasaZDictionary = FindObjectOfType<DictionaryC>();

        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();
        pomcol = column;
        pomrow = row;
       
            for (int i = -1 - k; i < 2 + k; i++)
            {
                pomrow = row;
                pomrow = pomrow + i;
                for (int j = -1 - k; j < 2 + k; j++)
                {
                    pomcol = column;
                    pomcol = pomcol + j;
                    test = "P" + pomrow + pomcol;
                    if (dictionaryTypes.ContainsKey(test))
                    {
                        Type typ = dictionaryTypes[test];
                        object obiekt = FindObjectOfType(typ);
                        Pole kolorObiekt = (Pole)obiekt;
                        kolorObiekt.pole = true;
                        kolorObiekt.green = true;
                        kolorObiekt.Kolor();

                    }

                }

            }       
    }

    public void Move( int columnStart, int rowStart)
    {
        Dictionary<string, Type> dictionaryTypes = klasaZDictionary.getDictionaryTypes();


            for (int i = -1 - k; i < 2 + k; i++)
            {
                pomrow = rowTemporary;
                pomrow = pomrow + i;
                for (int j = -1 - k; j < 2 + k; j++)
                {
                    pomcol = columnTemporary;
                    pomcol = pomcol + j;
                    test = "P" + pomrow + pomcol;
                    if (dictionaryTypes.ContainsKey(test))
                    {
                        Type typ = dictionaryTypes[test];
                        object obiekt = FindObjectOfType(typ);

                        Pole kolorObiekt = (Pole)obiekt;
                        kolorObiekt.pole = false;
                        kolorObiekt.green = false;
                        kolorObiekt.Kolor();
                    }

                }


            }
        

        while (rowTemporary != rowStart || columnTemporary != columnStart)
        {

            if (rowTemporary < rowStart)
            {
                rowTemporary++;
                rycerz2 = rycerz2 + 3;
                howManyMoves++;
            }
            else if (rowTemporary > rowStart)
            {
                rowTemporary--;
                rycerz2 = rycerz2 + 2;

                howManyMoves++;
            }

            if (columnTemporary < columnStart)
            {
                columnTemporary++;
                rycerz2 = rycerz2 + 1;

                howManyMoves++;
            }
            else if (columnTemporary > columnStart)
            {
                columnTemporary--;
                rycerz2 = rycerz2 + 4;

                howManyMoves++;
            }

        }
        if (id == 1)
        {
            Knight1.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Knight1.column = columnTemporary;
            Knight1.row = rowTemporary;

            Knight1.tablica = rycerz2;
            rycerz2 = "";
            ruch = FindObjectOfType<Knight1>();
            StartCoroutine(ruch.Movement());

        }
        if (id == 2)
        {
            Knight2.howManyMoves = howManyMoves;
            howManyMoves = 0;
            Knight2.column = columnTemporary;
            Knight2.row = rowTemporary;

            Knight2.tablica = rycerz2;
            rycerz2 = "";
            knight2 = FindObjectOfType<Knight2>();
            StartCoroutine(knight2.Movement());

        }
        howManyMoves = 0;

   

     
        row2 = rowTemporary;
        column2 = columnTemporary;
    }

}


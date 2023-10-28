using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryC : MonoBehaviour
{
    private Dictionary<string, Type> dictionaryTypes = new Dictionary<string, Type>
    {

    { "P11", typeof(P11) },
    { "P12", typeof(P12) },
    { "P13", typeof(P13) },
    { "P14", typeof(P14) },
    { "P21", typeof(P21) },
    { "P22", typeof(P22) },
    { "P23", typeof(P23) },
    { "P24", typeof(P24) },
    { "P31", typeof(P31) },
    { "P32", typeof(P32) },
    { "P33", typeof(P33) },
    { "P34", typeof(P34) },
    { "P41", typeof(P41) },
    { "P42", typeof(P42) },
    { "P43", typeof(P43) },
    { "P44", typeof(P44) },
    };

    public Dictionary<string, Type> getDictionaryTypes()
    {
        return dictionaryTypes;
    }
}
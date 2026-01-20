using System;
using UnityEngine;

public class ARObjectEvents : MonoBehaviour
{
    // Evento global: avisa quando um objeto AR foi criado
    public static Action<Transform> OnARObjectSpawned;
}

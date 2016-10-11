using UnityEngine;
using System.Collections;

public class Card {
    public int number;
    public int suit;
    public Card(int n, int s)
    {
        number = n;
        suit = s;
    }
    private Card() { }
}

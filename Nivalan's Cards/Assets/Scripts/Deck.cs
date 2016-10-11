using UnityEngine;
using System.Collections.Generic;

public class Deck {
    public List<Card> cards;
    public Deck()
    {
        cards = new List<Card>(52);
        Generate();
        cards.Shuffle();
    }
    private void Generate()
    {
        for(int i = 1; i <= 13; i++) //1 = ace 13 = King
        {
            for(int s = 1; s <= 4; s++)
            {
                Card tempCard = new Card(i, s);
                cards.Add(tempCard);
            }
        }
    }
}

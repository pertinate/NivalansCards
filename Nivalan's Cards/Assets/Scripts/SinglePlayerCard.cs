using UnityEngine;
using System.Collections;

public class SinglePlayerCard : MonoBehaviour {
    public static Deck deck;
    private bool canContinueCardGame = true;
    private void Awake()
    {
        deck = new Deck();
    }
    private IEnumerator doCardGame()
    {
        while (canContinueCardGame)
        {
            yield return new WaitForSeconds(0.5f);
        }
    }
}

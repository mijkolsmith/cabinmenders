using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterValues : MonoBehaviour
{
    [Header("Player 1 Values")]
    [SerializeField]
    private GameObject player1;
   
    public int _characterNumber1;

    [Space]
    [Header("Player 2 Values")]
    [SerializeField]
    private GameObject player2;
    
    public int _characterNumber2;

    private void Update()
    {
        player1 = GameObject.Find("PlayerUI");
        if (player1 != null)
            _characterNumber1 = player1.GetComponent<CharacterSelection>()._number;

        player2 = GameObject.Find("PlayerUI (1)");
        if (player2 != null)
            _characterNumber2 = player2.GetComponent<CharacterSelection>()._number;

        
    }
}

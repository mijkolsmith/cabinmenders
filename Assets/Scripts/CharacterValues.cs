using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterValues : MonoBehaviour
{
    [Header("Player 1 Values")]
    [SerializeField]
    private GameObject player1;
	private CharacterSelection player1cs;
	public int cNumber1;

    [Space]
    [Header("Player 2 Values")]
    [SerializeField]
    private GameObject player2;
	private CharacterSelection player2cs;
	public int cNumber2;

	private void Start()
	{
		cNumber1 = 0;
		cNumber2 = 1;
	}

    private void Update()
    {
		if (player1 == null)
		{
			player1 = GameObject.Find("Player1UI");
		}
		else if (player1 != null)
		{
			if (player1cs == null)
				player1cs = player1.GetComponent<CharacterSelection>();
			cNumber1 = player1cs._number;
		}
        
		if (player2 == null)
		{
			player2 = GameObject.Find("Player2UI");
		}
		else if (player2 != null)
		{
			if (player2cs == null)
				player2cs = player2.GetComponent<CharacterSelection>();
			cNumber2 = player2cs._number;
		}
	}
}
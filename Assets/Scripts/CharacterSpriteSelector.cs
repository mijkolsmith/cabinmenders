using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteSelector : MonoBehaviour
{
	private GameObject gm;

    [Space]
    [Header("Characters")]
	[SerializeField] private GameObject[] characters;

    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
	private int cNumber1;
	private int cNumber2;

    public string player;
    public string type;

    private void Start()
    {
        spawnPoint1 = GameObject.Find("Spawnpoint1");
        spawnPoint2 = GameObject.Find("Spawnpoint2");

		gm = GameManager.instance.gameObject;

		//this if statement is here so I can playtest in the editor and don't get the same character.
		if (gm.GetComponent<CharacterValues>().cNumber1 == gm.GetComponent<CharacterValues>().cNumber2)
		{
			cNumber1 = gm.GetComponent<CharacterValues>().cNumber1;
			cNumber2 = gm.GetComponent<CharacterValues>().cNumber2 + 1;
		}
		else
		{
			cNumber1 = gm.GetComponent<CharacterValues>().cNumber1;
			cNumber2 = gm.GetComponent<CharacterValues>().cNumber2;
		}

		if (gameObject.name == "Player1")
        {
            GameObject p1 = Instantiate(characters[cNumber1], spawnPoint1.transform.position, spawnPoint1.transform.rotation);
			p1.transform.SetParent(gameObject.transform);
            if (cNumber1 == 0)
                type = "Tape";
            if (cNumber1 == 1)
                type = "Glue";
            if (cNumber1 == 2)
                type = "Nail";
        }

        if (gameObject.name == "Player2")
        {
            GameObject p2 = Instantiate(characters[cNumber2], spawnPoint2.transform.position, spawnPoint2.transform.rotation);
			p2.transform.SetParent(gameObject.transform);
			if (cNumber2 == 0)
                type = "Tape";
            if (cNumber2 == 1)
                type = "Glue";
            if (cNumber2 == 2)
                type = "Nail";
        }
    }
}
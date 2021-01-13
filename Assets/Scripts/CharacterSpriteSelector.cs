using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject _GM;

    [Space]
    [Header("Characters")]
    public GameObject[] _ch;

    [SerializeField]
    private GameObject _spawnPoint1;
    [SerializeField]
    private GameObject _spawnPoint2;

	private int _cNumber1;
	private int _cNumber2;

    public string player;
    public string type;

    private void Start()
    {
        _spawnPoint1 = GameObject.Find("Spawnpoint1");
        _spawnPoint2 = GameObject.Find("Spawnpoint2");

		_GM = GameManager.instance.gameObject;
		if (_GM.GetComponent<CharacterValues>()._characterNumber1 == _GM.GetComponent<CharacterValues>()._characterNumber2)
		{
			_cNumber1 = _GM.GetComponent<CharacterValues>()._characterNumber1;
			_cNumber2 = _GM.GetComponent<CharacterValues>()._characterNumber2 + 1;
		}
		else
		{
			_cNumber1 = _GM.GetComponent<CharacterValues>()._characterNumber1;
			_cNumber2 = _GM.GetComponent<CharacterValues>()._characterNumber2;
		}

		if (gameObject.name == "Player1")
        {
            player = "p1";
            //gameObject.GetComponent<SpriteRenderer>().sprite = _characterSprite[_obj.GetComponent<CharacterValues>()._characterNumber1];
            GameObject p1 = Instantiate(_ch[_cNumber1], _spawnPoint1.transform.position, _spawnPoint1.transform.rotation);
			p1.transform.SetParent(gameObject.transform);
            if (_cNumber1 == 0)
                type = "Tape";
            if (_cNumber1 == 1)
                type = "Glue";
            if (_cNumber1 == 2)
                type = "Nail";
        }

        if (gameObject.name == "Player2")
        {
            player = "p2";	
            GameObject p2 = Instantiate(_ch[_cNumber2], _spawnPoint2.transform.position, _spawnPoint2.transform.rotation);
			p2.transform.SetParent(gameObject.transform);
			if (_cNumber2 == 0)
                type = "Tape";
            if (_cNumber2 == 1)
                type = "Glue";
            if (_cNumber2 == 2)
                type = "Nail";
        }
    }
}
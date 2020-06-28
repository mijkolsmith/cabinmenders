using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteSelector : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _characterSprite;

    [SerializeField]
    private GameObject _obj;

    [Space]
    [Header("Characters")]
    public GameObject[] _ch;

    [SerializeField]
    private GameObject _spawnPoint1;
    [SerializeField]
    private GameObject _spawnPoint2;

    public string player;
    public string type;

    private void Start()
    {
        _spawnPoint1 = GameObject.Find("Spawnpoint1");
        _spawnPoint2 = GameObject.Find("Spawnpoint2");

        _obj = GameObject.Find("GameManager(Clone)");

        if (gameObject.name == "Player1")
        {
            player = "p1";
            //gameObject.GetComponent<SpriteRenderer>().sprite = _characterSprite[_obj.GetComponent<CharacterValues>()._characterNumber1];
            GameObject p1 = Instantiate(_ch[_obj.GetComponent<CharacterValues>()._characterNumber1], _spawnPoint1.transform.position, _spawnPoint1.transform.rotation);
            p1.transform.parent = gameObject.transform;
            if(_obj.GetComponent<CharacterValues>()._characterNumber1 == 0)
                type = "Tape";
            if(_obj.GetComponent<CharacterValues>()._characterNumber1 == 1)
                type = "Glue";
            if(_obj.GetComponent<CharacterValues>()._characterNumber1 == 2)
                type = "Nail";

        }

        if (gameObject.name == "Player2")
        {
            player = "p2";
            GameObject p2 = Instantiate(_ch[_obj.GetComponent<CharacterValues>()._characterNumber2], _spawnPoint2.transform.position, _spawnPoint2.transform.rotation);
            p2.transform.parent = gameObject.transform;
            if (_obj.GetComponent<CharacterValues>()._characterNumber2 == 0)
                type = "Tape";
            if (_obj.GetComponent<CharacterValues>()._characterNumber2 == 1)
                type = "Glue";
            if (_obj.GetComponent<CharacterValues>()._characterNumber2 == 2)
                type = "Nail";
        }
    }
}

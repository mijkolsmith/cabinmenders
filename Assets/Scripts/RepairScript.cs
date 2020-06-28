using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairScript : MonoBehaviour
{
    public SpriteRenderer objectSprite;
    public CharacterController2D controller;
    string repairString;
    float timer;
    bool repairing = false;
    [SerializeField]
    Collider2D repairCol;
    [SerializeField] int TimeToRepair = 2;

    [SerializeField]
    private GameObject _gm;
    [SerializeField]
    string tag;

    private void Start()
    {
        repairString = transform.parent.name + " Repair";
        _gm = GameObject.Find("GameManager(Clone)");
    }

    private void Update()
    {
        if (repairing)
        {
            if (Input.GetButtonUp(repairString) || Input.GetAxisRaw(GetComponent<MoveScript>().horizontalString) != 0 || controller.m_Rigidbody2D.velocity.y > 0)
            {
                repairing = false;
                GetComponent<CharacterController2D>().anime.SetBool("isFixing", false);
            }
            timer += Time.deltaTime;
            if (Mathf.RoundToInt((timer % 60)) >= TimeToRepair)
            {
                SpriteUpdater();
                repairCol.gameObject.tag = "Untagged";

                timer = 0f;
                repairing = false;
                GetComponent<CharacterController2D>().anime.SetBool("isFixing", false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown(repairString) && !repairing && GetComponentInParent<CharacterSpriteSelector>().player == "p1")
        {
            if (other.gameObject.tag == "Ceramic" && _gm.GetComponent<CharacterValues>()._characterNumber1 != 2)
            {
                newFucnd(other);
            }
            if (other.gameObject.tag == "Wood" && _gm.GetComponent<CharacterValues>()._characterNumber1 != 0)
            {
                newFucnd(other);
            }
            if (other.gameObject.tag == "Cloth" && _gm.GetComponent<CharacterValues>()._characterNumber1 != 1)
            {
                newFucnd(other);
            }
        }
        if (Input.GetButtonDown(repairString) && !repairing && GetComponentInParent<CharacterSpriteSelector>().player == "p2")
        {
            if (other.gameObject.tag == "Ceramic" && _gm.GetComponent<CharacterValues>()._characterNumber2 != 2)
            {
                newFucnd(other);
            }
            if (other.gameObject.tag == "Wood" && _gm.GetComponent<CharacterValues>()._characterNumber2 != 0)
            {
                newFucnd(other);
            }
            if (other.gameObject.tag == "Cloth" && _gm.GetComponent<CharacterValues>()._characterNumber2 != 1)
            {
                newFucnd(other);
            }
        }
    }


    public void newFucnd(Collider2D other)
    {
        repairing = true;
        repairCol = other;
        GetComponent<CharacterController2D>().anime.SetBool("isFixing", true);
    }

    public void SpriteUpdater()
    {
        objectSprite = repairCol.GetComponent<SpriteRenderer>();
        tag = repairCol.gameObject.tag;
        if (gameObject.GetComponentInParent<CharacterSpriteSelector>().type == "Tape")
        {
            //Event
            if (tag == "Ceramic")
            {
                repairCol.gameObject.GetComponent<RepairObjectCeramic>().RepairWithTape(objectSprite);
            }
            else if (tag == "Cloth")
            {
                repairCol.gameObject.GetComponent<RepairObjectCloth>().RepairWithTape(objectSprite);
            }
        }
        if (gameObject.GetComponentInParent<CharacterSpriteSelector>().type == "Glue")
        {
            //Event
            if (tag == "Wood")
            {
                repairCol.gameObject.GetComponent<RepairObjectWood>().RepairWithGlue(objectSprite);
            }
            else if (tag == "Ceramic")
            {
                repairCol.gameObject.GetComponent<RepairObjectCeramic>().RepairWithGlue(objectSprite);
            }
        }
        if (gameObject.GetComponentInParent<CharacterSpriteSelector>().type == "Nail")
        {
            //Event
            if (tag == "Wood")
            {
                repairCol.gameObject.GetComponent<RepairObjectWood>().RepairWithNail(objectSprite); 
            }
            else if (tag == "Cloth")
            { 
                repairCol.gameObject.GetComponent<RepairObjectCloth>().RepairWithNail(objectSprite); 
            }
        }
    }
}
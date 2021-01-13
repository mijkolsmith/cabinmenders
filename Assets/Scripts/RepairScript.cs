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
    string repairTag;

    AudioSource audioSource;

    [SerializeField]
    AudioClip tapeClip;
    [SerializeField]
    AudioClip glueClip;
    [SerializeField]
    AudioClip nailClip;

	private Animator animator;
	private int cNumber1;
	private int cNumber2;
	private bool repairButtonDown;

	private void Start()
    {
        repairString = transform.parent.name + " Repair";
		_gm = GameManager.instance.gameObject;
		animator = GetComponent<CharacterController2D>().anime;
		audioSource = GetComponent<AudioSource>();
		cNumber1 = _gm.GetComponent<CharacterValues>()._characterNumber1;
		cNumber2 = _gm.GetComponent<CharacterValues>()._characterNumber2;
	}

    private void Update()
    {
		if (Input.GetButton(repairString))
		{
			repairButtonDown = true;
		}
		else
		{
			repairButtonDown = false;
		}

		if (repairing)
        {
            if (repairButtonDown = false || Input.GetAxisRaw(GetComponent<MoveScript>().horizontalString) != 0 || controller.m_Rigidbody2D.velocity.y > 0)
            {
				timer = 0f;
				repairing = false;
                animator.SetBool("isFixing", false);
            }

			timer += Time.deltaTime;
            if (Mathf.RoundToInt(timer % 60) >= TimeToRepair)
            {
                SpriteUpdater();
                repairCol.gameObject.tag = "Untagged";

                timer = 0f;
                repairing = false;
				animator.SetBool("isFixing", false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (repairButtonDown == true && !repairing && GetComponentInParent<CharacterSpriteSelector>().player == "p1")
        {
            if ((other.gameObject.tag == "Wood" && cNumber1 != 0) || 
				(other.gameObject.tag == "Cloth" && cNumber1 != 1) || 
				(other.gameObject.tag == "Ceramic" && cNumber1 != 2))
			{
				OnRepair(other);
            }
        }
        if (repairButtonDown == true && !repairing && GetComponentInParent<CharacterSpriteSelector>().player == "p2")
        {
            if ((other.gameObject.tag == "Wood" && cNumber2 != 0) || 
				(other.gameObject.tag == "Cloth" && cNumber2 != 1) || 
				(other.gameObject.tag == "Ceramic" && cNumber2 != 2))
            {
				OnRepair(other);
            }
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		timer = 0f;
		repairing = false;
		animator.SetBool("isFixing", false);
	}

	public void OnRepair(Collider2D other)
    {
        repairing = true;
        animator.SetBool("isFixing", true);

		repairCol = other;
	}

    public void SpriteUpdater()
    {
        objectSprite = repairCol.GetComponent<SpriteRenderer>();
        repairTag = repairCol.gameObject.tag;
        if (gameObject.GetComponentInParent<CharacterSpriteSelector>().type == "Tape")
        {
            if (repairTag == "Ceramic")
            {
                repairCol.gameObject.GetComponent<RepairObjectCeramic>().RepairWithTape(objectSprite);
                audioSource.PlayOneShot(tapeClip, 1f);
            }
            else if (repairTag == "Cloth")
            {
                repairCol.gameObject.GetComponent<RepairObjectCloth>().RepairWithTape(objectSprite);
                audioSource.PlayOneShot(tapeClip, 1f);
            }
        }
        if (gameObject.GetComponentInParent<CharacterSpriteSelector>().type == "Glue")
        {
            if (repairTag == "Wood")
            {
                repairCol.gameObject.GetComponent<RepairObjectWood>().RepairWithGlue(objectSprite);
                audioSource.PlayOneShot(glueClip, 1f);
            }
            else if (repairTag == "Ceramic")
            {
                repairCol.gameObject.GetComponent<RepairObjectCeramic>().RepairWithGlue(objectSprite);
                audioSource.PlayOneShot(glueClip, 1f);
            }
        }
        if (gameObject.GetComponentInParent<CharacterSpriteSelector>().type == "Nail")
        {
            if (repairTag == "Wood")
            {
                repairCol.gameObject.GetComponent<RepairObjectWood>().RepairWithNail(objectSprite);
                audioSource.PlayOneShot(nailClip, 1f);
            }
            else if (repairTag == "Cloth")
            { 
                repairCol.gameObject.GetComponent<RepairObjectCloth>().RepairWithNail(objectSprite);
                audioSource.PlayOneShot(nailClip, 1f);
            }
        }
    }
}
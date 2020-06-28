using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairObjectCloth : MonoBehaviour
{
    [Header("Cloth Repair")]
    [SerializeField]
    private Sprite nailRepairCloth;
    [SerializeField]
    private Sprite tapeRepairCloth;

    public void RepairWithNail(SpriteRenderer toRepair)
    {
        toRepair.sprite = nailRepairCloth;
    }
    public void RepairWithTape(SpriteRenderer toRepair)
    {
        toRepair.sprite = tapeRepairCloth;
    }
}

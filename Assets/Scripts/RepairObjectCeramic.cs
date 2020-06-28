using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairObjectCeramic : MonoBehaviour
{
    [Header("Ceramic Repair")]
    [SerializeField]
    private Sprite GlueRepairCeramic;
    [SerializeField]
    private Sprite TapeRepairCeramic;

    public void RepairWithGlue(SpriteRenderer toRepair)
    {
        toRepair.sprite = GlueRepairCeramic;
    }
    public void RepairWithTape(SpriteRenderer toRepair)
    {
        toRepair.sprite = TapeRepairCeramic;
    }
}

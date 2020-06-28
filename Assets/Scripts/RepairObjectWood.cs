using UnityEngine;

public class RepairObjectWood : MonoBehaviour
{
    [Header("Wood Repair")]
    [SerializeField]
    private Sprite nailRepairWood;
    [SerializeField]
    private Sprite glueRepairWood;

    public void RepairWithNail(SpriteRenderer toRepair)
    {
        toRepair.sprite = nailRepairWood;
    } 
    public void RepairWithGlue(SpriteRenderer toRepair)
    {
        toRepair.sprite = glueRepairWood;
    }
}

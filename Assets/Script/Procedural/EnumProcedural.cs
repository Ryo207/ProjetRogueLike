using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumProcedural : MonoBehaviour
{
    public GameObject[] Broom;

    public GameObject[] BLroom;

    public GameObject[] BLRroom;
    public GameObject[] BRroom;
    public GameObject[] Lroom;
    public GameObject[] LRroom;
    public GameObject[] Rroom;
    public GameObject[] Troom;
    public GameObject[] TBroom;
    public GameObject[] TBLroom;
    public GameObject[] TBLRroom;
    public GameObject[] TBRroom;
    public GameObject[] TLroom;
    public GameObject[] TLRroom;
    public GameObject[] TRroom;

    private int rand;

    public roomType type;

    public enum roomType
    {
        B_room, BL_room, BLR_room, BR_room, L_room, LR_room, R_room, T_room, TB_room, TBL_room, TBLR_room, TBR_room, TL_room, TLR_room, TR_room  

    }

    void Start()
    {
        switch (type)
        {
            case roomType.B_room:
                rand = Random.Range(0, Broom.Length);
                Instantiate(Broom[rand], transform.position, Broom[rand].transform.rotation);
                break;
            case roomType.BL_room:
                rand = Random.Range(0, BLroom.Length);
                Instantiate(BLroom[rand], transform.position, BLroom[rand].transform.rotation);
                break;
            case roomType.BLR_room:
                rand = Random.Range(0, BLRroom.Length);
                Instantiate(BLRroom[rand], transform.position, BLRroom[rand].transform.rotation);
                break;
            case roomType.BR_room:
                rand = Random.Range(0, BRroom.Length);
                Instantiate(BRroom[rand], transform.position, BRroom[rand].transform.rotation);
                break;
            case roomType.L_room:
                rand = Random.Range(0, Lroom.Length);
                Instantiate(Lroom[rand], transform.position, Lroom[rand].transform.rotation);
                break;
            case roomType.LR_room:
                rand = Random.Range(0, LRroom.Length);
                Instantiate(LRroom[rand], transform.position, LRroom[rand].transform.rotation);
                break;
            case roomType.R_room:
                rand = Random.Range(0, Rroom.Length);
                Instantiate(Rroom[rand], transform.position, Rroom[rand].transform.rotation);
                break;
            case roomType.T_room:
                rand = Random.Range(0, Troom.Length);
                Instantiate(Troom[rand], transform.position, Troom[rand].transform.rotation);
                break;
            case roomType.TB_room:
                rand = Random.Range(0, TBroom.Length);
                Instantiate(TBroom[rand], transform.position, TBroom[rand].transform.rotation);
                break;
            case roomType.TBL_room:
                rand = Random.Range(0, TBLroom.Length);
                Instantiate(TBLroom[rand], transform.position, TBLroom[rand].transform.rotation);
                break;
            case roomType.TBLR_room:
                rand = Random.Range(0, TBLRroom.Length);
                Instantiate(TBLRroom[rand], transform.position, TBLRroom[rand].transform.rotation);
                break;
            case roomType.TBR_room:
                rand = Random.Range(0, TBRroom.Length);
                Instantiate(TBRroom[rand], transform.position, TBRroom[rand].transform.rotation);
                break;
            case roomType.TL_room:
                rand = Random.Range(0, TLroom.Length);
                Instantiate(TLroom[rand], transform.position, TLroom[rand].transform.rotation);
                break;
            case roomType.TLR_room:
                rand = Random.Range(0, TLRroom.Length);
                Instantiate(TLRroom[rand], transform.position, TLRroom[rand].transform.rotation);
                break;
            case roomType.TR_room:
                rand = Random.Range(0, TRroom.Length);
                Instantiate(TRroom[rand], transform.position, TRroom[rand].transform.rotation);
                break;
            default:
                break;
        }

       
    }

    void Update()
    {
        
    }
}

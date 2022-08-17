using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SelectSoldier : MonoBehaviour
{
    public GameObject uiText;
    public GameObject defenseSOlders;
    public GameObject atRe;
    public Transform spawnPoint;
    public VisualEffect teleportParticle;
    GameObject Player;

    public void SpawnSoldier(GameObject soldier) {
        teleportParticle.Play();
        Instantiate(soldier, spawnPoint.position, transform.rotation);
        
        uiText.SetActive(false);
        defenseSOlders.SetActive(true);
        atRe.SetActive(true);
    }

    public void SwitchSoldier() {
        uiText.SetActive(true);
        defenseSOlders.SetActive(false);
        atRe.SetActive(false);
        GameObject RifleSoldier = GameObject.Find("RifleSoldier(Clone)");
        GameObject MachineGunSoldier = GameObject.Find("MachineGunSoldier(Clone)");
        GameObject SniperSoldier = GameObject.Find("SniperSoldier(Clone)");
        
        if(RifleSoldier) Player = RifleSoldier;
        if(MachineGunSoldier) Player = MachineGunSoldier;
        if(SniperSoldier) Player = SniperSoldier;
        Destroy(Player);
    }
}

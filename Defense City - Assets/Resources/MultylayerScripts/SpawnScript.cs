using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Photon.Pun;

public class SpawnScript : MonoBehaviour
{
    public GameObject uiText;
    public GameObject defenseSOlders;
    public GameObject atRe;
    public Transform spawnPoint;
    public VisualEffect teleportParticle;
    GameObject Player;

    public void SpawnSoldier(GameObject soldier) {
        teleportParticle.Play();
        PhotonNetwork.Instantiate(soldier.name, spawnPoint.position, spawnPoint.rotation);

        uiText.SetActive(false);
        defenseSOlders.SetActive(true);
        atRe.SetActive(true);
    }

    public void SwitchSoldier() {
        uiText.SetActive(true);
        defenseSOlders.SetActive(false);
        atRe.SetActive(false);
    }

    public void SpawnDefenseSoldier(GameObject Soldier) {
        Instantiate(Soldier, transform.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Destroyifnotowner : NetworkBehaviour
{
    [SerializeField] private GameObject A;
    [SerializeField] private GameObject B;
    [SerializeField] private GameObject C;
    [SerializeField] private GameObject D;
    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            Destroy(A);
            Destroy(B);
            Destroy(C);
            Destroy(D);
            Destroy(this.gameObject);
        }
    }
}

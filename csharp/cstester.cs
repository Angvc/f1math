using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class cstester : MonoBehaviour
{
    [SerializeField] GameObject self;
    // Start is called before the first frame update
    public void client()
    {
        NetworkManager.Singleton.StartClient();
        Destroy(self);
    }

    public void server()
    {
        NetworkManager.Singleton.StartServer();
        Destroy(self);
    }

    public void host()
    {
        NetworkManager.Singleton.StartHost();
        Destroy(self);
    }
}

using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using TMPro;
using System.Net;
using System.Net.Sockets;

public class IPSettings : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ipAddressText;
    [SerializeField] TMP_InputField ip;
    [SerializeField] string ipAddress;
    [SerializeField] UnityTransport transport;
    // Start is called before the first frame update
    void Start()
    {
        ipAddress = "0.0.0.0";
        SetIpAddress(); // Set the Ip to the above address
    }

    // Update is called once per frame
    void Update()
    {/*
        if (NetworkManager.Singleton.IsHost && !NetworkManager.Singleton.IsClient)
        {
            GetLocalIPAddress();
        }*/
        }
    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                ipAddressText.text = ip.ToString();
                ipAddress = ip.ToString();
                return ip.ToString();
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
    public void GetLocalIPAddress2()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                ipAddressText.text = ip.ToString();
                ipAddress = ip.ToString();
                return;
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
    public void SetIpAddress()
    {
        ipAddress = ip.text;
        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.ConnectionData.Address = ipAddress;
    }
}

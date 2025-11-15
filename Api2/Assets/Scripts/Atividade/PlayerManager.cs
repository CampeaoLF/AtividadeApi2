using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI Vida;
    public float life = 50;
    public GameObject Player;
    public int iten = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null) 
        {
            iten++;
            life -= 5;
            //Object.Destroy(collision.gameObject);

        }
    }
}

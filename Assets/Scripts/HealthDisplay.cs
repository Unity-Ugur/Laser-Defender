using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text health;

    private Player player; 
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = player.GetHealth().ToString();
    }
}

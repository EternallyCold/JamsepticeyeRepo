using UnityEngine;
using UnityEngine.SceneManagement;

public class Drown : MonoBehaviour
{
    [SerializeField] public Transform DrownCheck;
    [SerializeField] public LayerMask DrownLayer;


    void Update()
    {
        
        if (IsDrowned())
        {
            SceneManager.LoadScene("WinScreen");
        }

    }
    private bool IsDrowned()
    {
        return Physics2D.OverlapCircle(DrownCheck.position, 0.2f, DrownLayer);
    }
}

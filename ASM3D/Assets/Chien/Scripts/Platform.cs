using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeTrigger : MonoBehaviour
{
    // Hàm này sẽ được gọi khi một đối tượng có Collider chạm vào Cube
    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem đối tượng chạm vào có tag là "Player"
        if (other.CompareTag("Player"))
        {
            // Chuyển sang Scene có tên "Boss"
            SceneManager.LoadScene(2);
        }
    }
}


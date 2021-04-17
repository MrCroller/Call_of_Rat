using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _trigger_nand;
    [SerializeField] public Transform p_camera;
    public Transform startPosition;

    /// <summary>
    /// Кол-во ключей игрока (5 для открытия)
    /// </summary>
    public int key_count = 0;


    private void Update()
    {
        TakeHand();
    }

    /// <summary>
    /// Взаимодействие с объектами
    /// </summary>
    private void TakeHand()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _trigger_nand.SetActive(true);
            Debug.Log("enter_e");

            // Поворот тригера в сторону камеры
            _trigger_nand.transform.rotation = p_camera.rotation;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _trigger_nand.SetActive(false);
        }

    }

    public void Death()
    {
        Debug.Log("Died");
        transform.position = startPosition.position;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}

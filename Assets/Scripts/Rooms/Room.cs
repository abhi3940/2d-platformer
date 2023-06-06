using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] enimes;
    private Vector3[] initialPosition;

    private void Awake()
    {
        //save the initial position of all the enemies
        initialPosition = new Vector3[enimes.Length];
        for (int i = 0; i < enimes.Length; i++)
        {
            if (enimes[i] != null)
                initialPosition[i] = enimes[i].transform.position;
        }
    }
    public void ActivateRoom(bool _status)
    {
        //active/deactivate enimies
        for (int i = 0; i < enimes.Length; i++)
        {
            if (enimes[i] != null)
            {
                enimes[i].SetActive(_status);
                enimes[i].transform.position = initialPosition[i];

            }
        }
    }
}

using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] RowCollider[] m_Rows;
    [SerializeField] bool[] m_Trackers;

    static Follower s_Instance = null;
    private void Start()
    {
        s_Instance = this;
        m_Trackers = new bool[m_Rows.Length];
    }

    private void LateUpdate()
    {
        // Makes the follower follow the player but ignores which row it is in //
        Vector3 pos = Player.Instance().transform.position;
        pos.x = 0;
        transform.position = pos;

        for (int i = 0; i < m_Rows.Length; i++)
        {
            m_Trackers[i] = m_Rows[i].IsRowClear();
        }
    }

    // Don't ask why it's minus 4 this is just duck tape please ignore //
    public static bool IsRowClear(int index) => s_Instance.m_Rows[4 - index].IsRowClear();
}

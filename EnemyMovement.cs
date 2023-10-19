using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int damageToBase = 10;  // ������ɵ��˺�
    private Transform[] waypoints;  // �������ߵ�·����
    private int currentWaypointIndex;  // ��ǰĿ��·���������
    private BaseHealth baseHealth; // ��Ӫ������ֵ�ű�

    public float moveSpeed = 2f;  // �����ƶ��ٶ�

    private void Start()
    {
        currentWaypointIndex = 0;
        baseHealth = GameObject.Find("Base").GetComponent<BaseHealth>(); // ��ȷ����Ĵ�Ӫ���������Ϊ "Base"��������ǣ��뽫���滻Ϊ��ȷ������
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    public void SetWaypoints(Transform[] waypoints)
    {
        this.waypoints = waypoints;
        currentWaypointIndex = 0; // ���õ�ǰĿ��·����Ϊ����ĵ�һ��·����
    }

    private void MoveToWaypoint()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        // �ƶ�����ǰĿ��·����
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // ����Ƿ񵽴ﵱǰ·����
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // ����ʹ��С�� 0.1f ����ֵ
        {
            // ������һ��Ŀ��·���������
            currentWaypointIndex++;
            // ����������յ㣬�����ٵ���
            if (currentWaypointIndex >= waypoints.Length)
            {
                if (baseHealth != null)
                {
                    baseHealth.TakeDamage(damageToBase); // ���ٴ�Ӫ����ֵ
                }
                Destroy(gameObject);
            }
        }
    }
}

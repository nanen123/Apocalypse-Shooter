using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "Scriptable Objects/GunStats")]
public class GunStats : ScriptableObject
{
    public float damage; // ������
    
    public int remainAmmo; // ���� źâ�� �����ִ� �Ѿ�
    public int maxAmmo; // �� źâ �ִ� �Ѿ�

    public float reloadingTime; // ������ �ð�
}

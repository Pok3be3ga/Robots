using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]        Transform playyerTransform;
    [SerializeField]        float createRadius;
    [SerializeField]        ChaptorSettings chaptorSettings;
    List<Enemy> enemyList = new List<Enemy>();

    

    public void StartNewWave(int _wave)
    {
        StopAllCoroutines();
        for (int i = 0; i < chaptorSettings.EnamyWavesArray.Length; i++)
        {
            if (chaptorSettings.EnamyWavesArray[i].NumberPerSecond[_wave] > 0)
            {
                StartCoroutine(CreateEmenyInSeconds(chaptorSettings.EnamyWavesArray[i].Enemy, chaptorSettings.EnamyWavesArray[i].NumberPerSecond[_wave]));
            }
            
        }
    }
    IEnumerator CreateEmenyInSeconds(Enemy _enemy, float _enemyPerSecond)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / _enemyPerSecond);
            Create(_enemy);
        }
    }

    public void Create(Enemy _enemy)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 _position = new Vector3(randomPoint.x, 0, randomPoint.y) * createRadius + playyerTransform.position;
        Enemy _newEnemy = Instantiate(_enemy, _position, Quaternion.identity);
        _newEnemy.Init(playyerTransform, this);
        enemyList.Add(_newEnemy);


    }

    public void RemoveEnemy(Enemy _enemy)
    {
        enemyList.Remove(_enemy);
    }

    public Enemy[] GetNearest(Vector3 _point, int _number)
    {
        enemyList = enemyList.OrderBy(x => Vector3.Distance(_point, x.transform.position)).ToList();

        int _returnNumber = Mathf.Min(_number, enemyList.Count);
        Enemy[] _enimies = new Enemy[_returnNumber];
        for (int i = 0; i < _returnNumber; i++)
        {
            _enimies[i] = enemyList[i];
        }
        return _enimies;
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Handles.color = Color.red;
        Handles.DrawWireDisc(playyerTransform.position, Vector3.up, createRadius);
#endif
    }


}

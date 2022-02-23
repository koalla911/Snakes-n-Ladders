using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler
{
    public class PoolerAlgorithm
    {
        private int _numberOfPoints;
        private int _numberOfEntities;


        public PoolerAlgorithm(int numberOfPoints, int numberOfEntities)
        {
            (_numberOfPoints, _numberOfEntities) = (numberOfPoints, numberOfEntities);
        }


        public void GetListOfACoefficient(int[] arrayToFill)
        {
            int a = 0;

            int currentA = 0;
            int n = _numberOfEntities;
            int k = _numberOfPoints;

            for (int i = 0; i < _numberOfPoints - 1; i++)
            {
                currentA = (n - a) - (k - (i + 1));

                arrayToFill[i] = Random.Range(1, currentA);

                a += arrayToFill[i];
            }

            int lastNum = n - a;

            arrayToFill[k - 1] = lastNum;
        }
    }
}
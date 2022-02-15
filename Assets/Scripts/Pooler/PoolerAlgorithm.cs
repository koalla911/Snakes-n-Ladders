using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler
{
    public class PoolerAlgorithm
    {
        public int Point { get; set; }
        public int Entity { get; set; }

        private int[] _listOfA;

        /*private int _a = 0;
        private int _currentA = 0;
        private int _n;
        private int _k;*/

        public PoolerAlgorithm(int point, int entity)
        {
            (Point, Entity) = (point, entity);
            //(_k, _n) = (point, entity);
        }


        public void GetListOfACoefficient(int[] arrayToFill)
        {
            int a = 0;

            int currentA = 0;
            int n = Entity;
            int k = Point;

            //_listOfA = new int[Point];

            for (int i = 0; i < Point - 1; i++)
            {
                currentA = (n - a) - (k - (i + 1));

                arrayToFill[i] = Random.Range(1, currentA);

                a += arrayToFill[i];
            }

            int lastNum = n - a;

            arrayToFill[k - 1] = lastNum;

            //return _listOfA;
        }
    }
}
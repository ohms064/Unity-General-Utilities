using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity_General_Utilities.Runtime
{
    [System.Serializable]
    public class Weight<T>
    {
        [SerializeField] private int weightValue = 1;
        [SerializeField] private T value;

        public int WeightValue => weightValue;

        public T Value => value;
    }

    [System.Serializable]
    public class WeightGroup<T>
    {
        [SerializeField] private List<Weight<T>> weightList;

        public int Count => weightList.Count;

        public int TotalWeightValue => weightList.Sum(w => w.WeightValue);

        public T GetWeightValue(float t)
        {
            var weightValue = Mathf.FloorToInt(t * TotalWeightValue);
            return GetWeightValue(weightValue);
        }

        public T GetWeightValue(int t)
        {
            return GetWeightValueFrom(t, weightList).Value;
        }
        
        public List<T> GetWeightMultiple(IEnumerable<float> weightParams)
        {
            var weightValue = weightParams.Select(t => Mathf.FloorToInt(t * TotalWeightValue));
            return GetWeightMultiple(weightValue);
        }

        public List<T> GetWeightMultiple(IEnumerable<int> weightParams)
        {
            var copy = new List<Weight<T>>(weightList);
            var result = new List<T>();
            foreach (var t in weightParams)
            {
                var weight = GetWeightValueFrom(t, copy);
                result.Add(weight.Value);
                copy.Remove(weight);
            }

            return result;
        }

        private static Weight<T> GetWeightValueFrom(int t, IEnumerable<Weight<T>> weightList)
        {
            var weightAccumulator = 0;
            foreach (var weight in weightList)
            {
                if (weightAccumulator <= t)
                {
                    return weight;
                }
                weightAccumulator += weight.WeightValue;
            }

            return default;

        }
    }
}
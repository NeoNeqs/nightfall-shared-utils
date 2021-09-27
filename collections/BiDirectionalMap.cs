using System;
using System.Collections;
using System.Collections.Generic;
using Nightfall.SharedUtils.InfoCodes;

namespace Nightfall.SharedUtils.Collections
{
    public class BiDirectionalMap<TKey, TValue> : IEnumerable<Tuple<TKey, TValue>>
    {
        private readonly Dictionary<TKey, TValue> _forward;
        private readonly Dictionary<TValue, TKey> _backwards;

        public BiDirectionalMap() : this(null, null)
        {
        }

        public BiDirectionalMap(IEqualityComparer<TKey> comparer1, IEqualityComparer<TValue> comparer2)
        {
            _forward = new Dictionary<TKey, TValue>(comparer1);
            _backwards = new Dictionary<TValue, TKey>(comparer2);
        }

        private bool ContainsKey(TKey key)
        {
            return _forward.ContainsKey(key);
        }

        private bool ContainsValue(TValue value)
        {
            return _backwards.ContainsKey(value);
        }

        public NFError Add(TKey key, TValue value)
        {
            if (ContainsKey(key) || ContainsValue(value))
            {
                return NFError.AlreadyExists;
            }

            _forward[key] = value;
            _backwards[value] = key;

            return NFError.Ok;
        }

        public NFError TryGetValue(TKey key, out TValue value)
        {
            return _forward.TryGetValue(key, out value) ? NFError.Ok : NFError.DoesNotExist;
        }

        public NFError TryGetKey(TValue value, out TKey key)
        {
            return _backwards.TryGetValue(value, out key) ? NFError.Ok : NFError.DoesNotExist;
        }


        public IEnumerator<Tuple<TKey, TValue>> GetEnumerator()
        {
            foreach (var (key, value) in _forward)
                yield return Tuple.Create(key, value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public NFError Remove(TValue value)
        {
            if (_backwards.Remove(value, out var key) && _forward.Remove(key))
            {
                return NFError.Ok;
            }

            return NFError.UnsuccessfulRemoval;
        }

        public NFError Remove(TKey key)
        {
            if (_forward.Remove(key, out var value) && _backwards.Remove(value))
            {
                return NFError.Ok;
            }

            return NFError.UnsuccessfulRemoval;
        }
    }
}
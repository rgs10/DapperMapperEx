// <copyright file="DapperHelper.cs" company="Advanced Health and Care Limited">
// Copyright © 2015 Advanced Health and Care Limited - All Rights Reserved.
// </copyright>
// <summary>Implements the DapperHelper</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using DapperWrapper.Interfaces;


namespace ComplexObjectMapping.Dapper
{
    /// <summary>
    /// A helper class to provide mapping of child
    /// objects to parent (many to one)
    /// </summary>
    public static class DapperHelper
    {
        /// <summary>
        /// Mapper Helper Class to create object hierarchy
        /// in for use with Dapper 
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="reader"></param>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="firstKey"></param>
        /// <param name="secondKey"></param>
        /// <param name="addChildren"></param>
        /// <returns></returns>
        public static IEnumerable<TFirst> MapChild<TFirst, TSecond, TKey>
            (
            this IGridReader reader,
            List<TFirst> parent,
            List<TSecond> child,
            Func<TFirst, TKey> firstKey,
            Func<TSecond, TKey> secondKey,
            Action<TFirst, IEnumerable<TSecond>> addChildren
            )
        {
            var childMap = child
                .GroupBy(secondKey)
                .ToDictionary(g => g.Key, g => g.AsEnumerable());
            foreach (var item in parent)
            {
                IEnumerable<TSecond> children;
                if (childMap.TryGetValue(firstKey(item), out children))
                {
                    addChildren(item, children);
                }
                else
                {
                    addChildren(item, new List<TSecond>());
                }
            }
            return parent;
        }
    }
}
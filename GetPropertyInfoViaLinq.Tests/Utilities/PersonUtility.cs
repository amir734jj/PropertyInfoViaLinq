using System;
using System.Linq.Expressions;
using GetPropertyInfoViaLinq.Tests.Models;

namespace GetPropertyInfoViaLinq.Tests.Utilities
{
    public class PersonUtility
    {
        /// <summary>
        /// Converts Func to lambda of Func
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public static Expression<Func<Person, object>> LambdaToExp(Expression<Func<Person, object>> lambda)
        {
            return lambda;
        }
    }
}
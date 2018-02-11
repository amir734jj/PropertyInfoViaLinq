using System;
using System.Linq.Expressions;
using System.Reflection;
using GetPropertyInfoViaLinq.Interfaces;
using GetPropertyNameViaLinq;

namespace GetPropertyInfoViaLinq
{
    public class GetPropertyInfoViaLinq<T> : IGetPropertyInfoViaLinq<T>
    {
        /// <summary>
        /// Converts lambda expression to member expression
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual MemberExpression ToMemeberExpression(Expression<Func<T, object>> exp)
        {
            MemberExpression resultExp;
            var body = exp.Body;
            
            switch (body)
            {
                case MemberExpression memberExpression:
                    resultExp = memberExpression;
                    break;
                case UnaryExpression unaryExpression:
                    resultExp = unaryExpression.Operand as MemberExpression;
                    break;
                case LambdaExpression memberExpression:
                    throw new Exception("Lambda expressions cannot be decomposed!");
                default:
                    throw new Exception("Something is wrong with the type!");
            }
            
            return resultExp;
        }

        /// <summary>
        /// Returns member name of member expression
        /// </summary>
        /// <param name="memberExpression"></param>
        /// <returns></returns>
        protected virtual string GetMemberExpressionName(MemberExpression memberExpression)
        {
            return memberExpression.Member.Name;
        }

        /// <summary>
        /// Returns property name using lambda
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string GetPropertyName(Expression<Func<T, object>> expression)
        {
            // convert lambda arg to memeber expression safely
            var memberExpresion = ToMemeberExpression(expression);
            
            // create a list of property names
            var nameTokens = new LinkedListWithInit<string>() { GetMemberExpressionName(memberExpresion) };
            
            // get nested expression
            var parentExp = memberExpresion.Expression;

            // while nested expression is member expression
            while (parentExp is MemberExpression parentMemberExpression)
            {
                // add string property name to the list
                nameTokens.AddFirst(GetMemberExpressionName(parentMemberExpression));

                // reset the parentExp to go one more level deep 
                parentExp = parentMemberExpression.Expression;
            }

            // joun the tokens together
            return string.Join(".", nameTokens);
        }

        /// <summary>
        /// Returns a attribute via linq
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public virtual Attribute GetAttribute(Expression<Func<T, object>> expression, Type attributeType)
        {
            var memberExpression = ToMemeberExpression(expression);

            return memberExpression.Member.GetCustomAttribute(attributeType);
        }
    }
}
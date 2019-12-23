using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AIShellAn.Server
{
    /// <summary>
    /// 表达式构建    
    /// </summary>
    /// <example>
    /// var build = new PredicateBuilder %3C User %3e(true).And(o=>o.UserName=="wuchang").And(o=>o.PasswordHash="123")
    /// dbContent.User.Where( build.Expression );
    /// 等于
    /// dbContent.User.Where( o=> o.UserName=="wuchang" %26%26 o.PasswordHash="123" )
    /// </example>
    /// <typeparam name="T"></typeparam>
    public class PredicateBuilder<T> where T : class
    {
        internal Expression<Func<T, bool>> expression;
        public PredicateBuilder(bool defaultExpression)
        {
            expression = defaultExpression ? PredicateExtensions.True<T>() : PredicateExtensions.False<T>();
        }

        public PredicateBuilder<T> And(Expression<Func<T, bool>> rigthExpression)
        {
            this.expression = PredicateExtensions.And(this.expression, rigthExpression);
            return this;
        }
        public PredicateBuilder<T> Or(Expression<Func<T, bool>> rigthExpression)
        {
            this.expression = PredicateExtensions.Or(this.expression, rigthExpression);
            return this;
        }

        public Expression<Func<T, bool>> Expression => this.expression;
    }

    public class PredicateBuilder
    {
        public static PredicateBuilder<T> Create<T>(bool defaultExpression) where T : class
        {
            return new PredicateBuilder<T>(defaultExpression);
        }
    }


    public static class PredicateBuilderExtenstions
    {
        public static PredicateBuilder<T> AndIf<T>(this PredicateBuilder<T> build, bool condition, Expression<Func<T, bool>> rigthExpression) where T : class
        {
            if (condition)
                build.expression = PredicateExtensions.And(build.Expression, rigthExpression);
            return build;
        }

        public static PredicateBuilder<T> OrIf<T>(this PredicateBuilder<T> build, bool condition, Expression<Func<T, bool>> rigthExpression) where T : class
        {
            if (condition)
                build.expression = PredicateExtensions.Or(build.Expression, rigthExpression);

            return build;
        }

        /// <summary>
        /// 非空字符串和空格字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="build"></param>
        /// <param name="str"></param>
        /// <param name="rigthExpression"></param>
        /// <returns></returns>
        public static PredicateBuilder<T> AndIfNotEmpty<T>(this PredicateBuilder<T> build, string str, Expression<Func<T, bool>> rigthExpression) where T : class
        {
            if (!string.IsNullOrWhiteSpace(str))
                build.expression = PredicateExtensions.And(build.Expression, rigthExpression);
            return build;
        }

        /// <summary>
        /// 非空字符串和空格字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="build"></param>
        /// <param name="str"></param>
        /// <param name="rigthExpression"></param>
        /// <returns></returns>
        public static PredicateBuilder<T> OrIfNotEmpty<T>(this PredicateBuilder<T> build, string str, Expression<Func<T, bool>> rigthExpression) where T : class
        {
            if (!string.IsNullOrWhiteSpace(str))
                build.expression = PredicateExtensions.Or(build.Expression, rigthExpression);
            return build;
        }

        /// <summary>
        /// 非空集合 not null and .Any()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="build"></param>
        /// <param name="src"></param>
        /// <param name="rigthExpression"></param>
        /// <returns></returns>
        public static PredicateBuilder<T> AndIfNotEmpty<T>(this PredicateBuilder<T> build, IEnumerable src, Expression<Func<T, bool>> rigthExpression) where T : class
        {
            if (src != null && src.GetEnumerator().MoveNext())
                build.expression = PredicateExtensions.And(build.Expression, rigthExpression);
            return build;
        }


        /// <summary>
        /// 非空集合 not null and  .Any()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="build"></param>
        /// <param name="src"></param>
        /// <param name="rigthExpression"></param>
        /// <returns></returns>
        public static PredicateBuilder<T> OrIfNotEmpty<T>(this PredicateBuilder<T> build, IEnumerable src, Expression<Func<T, bool>> rigthExpression) where T : class
        {
            if (src != null && src.GetEnumerator().MoveNext())
                build.expression = PredicateExtensions.Or(build.Expression, rigthExpression);
            return build;
        }

        /// <summary>
        ///  非空对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="build"></param>
        /// <param name="obj"></param>
        /// <param name="rigthExpression"></param>
        /// <returns></returns>
        public static PredicateBuilder<T> AndIfNotNull<T>(this PredicateBuilder<T> build, object obj, Expression<Func<T, bool>> rigthExpression) where T : class
        {
            if (obj != null)
                build.expression = PredicateExtensions.And(build.Expression, rigthExpression);
            return build;
        }

        /// <summary>
        ///  非空对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="build"></param>
        /// <param name="obj"></param>
        /// <param name="rigthExpression"></param>
        /// <returns></returns>
        public static PredicateBuilder<T> OrIfNotNull<T>(this PredicateBuilder<T> build, object obj, Expression<Func<T, bool>> rigthExpression) where T : class
        {
            if (obj != null)
                build.expression = PredicateExtensions.Or(build.Expression, rigthExpression);
            return build;
        }


       

    }
}

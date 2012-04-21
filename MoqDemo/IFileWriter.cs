namespace MoqDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IFileWriter
    {
        void WriteLine(string s);
        void Filter(IEnumerable<Expression<Func<Order, bool>>> criteris);
        string FileName { set; get; }
    }
}
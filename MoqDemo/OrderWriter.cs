namespace MoqDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class OrderWriter
    {
        private readonly IFileWriter _fileWriter;
        public OrderWriter(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void WriteOrder(Order order)
        {
            // set filename first
            _fileWriter.FileName = order.OrderId + ".txt";
            _fileWriter.WriteLine(string.Format("{0}, {1}", order.OrderId, order.OrderTotal));
        }

        public void DoSomeFilteration()
        {
            var conditions = new List<Expression<Func<Order, bool>>>();
            conditions.Add(c=> c.OrderId == 101);
            conditions.Add(c=> c.OrderTotal == 1000.45m);

            _fileWriter.Filter(conditions.ToArray());
        }
    }
}

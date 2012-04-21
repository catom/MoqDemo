namespace MoqDemo.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class OrderWriterTests
    {

        [Test]
        public void Write_Can_Write_To_File()
        {
            Order order = new Order {OrderId = 1001, OrderTotal = 10.3m};
            Mock<IFileWriter> fileWriterMock = new Mock<IFileWriter>();
 
            OrderWriter writer = new OrderWriter(fileWriterMock.Object);
            writer.WriteOrder(order);

            fileWriterMock.Verify(fw=> fw.WriteLine("1001, 10.3"), Times.Exactly(1));
        }

        [Test]
        public void Write_Can_Set_File_Name()
        {
            Mock<IFileWriter> fileWriter = new Mock<IFileWriter>();
            OrderWriter writer = new OrderWriter(fileWriter.Object);
            writer.WriteOrder(new Order());

            fileWriter.VerifySet(c => c.FileName, Times.Exactly(1));
        }

        [Test]
        public void Write_Can_Filter_With_Values()
        {
            Mock<IFileWriter> fileWriter = new Mock<IFileWriter>();
            OrderWriter writer = new OrderWriter(fileWriter.Object);

            fileWriter.Setup(c=> c.Filter(It.IsAny<IEnumerable<Expression<Func<Order, bool>>>>())).AtMostOnce().Verifiable();

            writer.DoSomeFilteration();

           fileWriter.VerifyAll();
        }
    }
}

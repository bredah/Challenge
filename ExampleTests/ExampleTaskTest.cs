using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace challenge
{
  [TestClass]
  public class ExampleTaskTest
  {
     private Mock<ISimpleTask> mock = new Mock<ISimpleTask>();

    [TestInitialize]
    public void setup()
    {
      mock.Setup(m => m.DoSomething()).Verifiable();
    }

    [TestCleanup]
    public void clean()
    {
      mock.Reset();
    }


    [TestMethod]
    public async Task CheckTaskA()
    {
      using (ExampleTask runner = new ExampleTask(mock.Object))
      {
        await runner.Task_A();
        mock.Verify(x => x.DoSomething(), Times.Exactly(5));
      }
    }


    [TestMethod]
    public async Task CheckTaskB()
    {
      using (ExampleTask runner = new ExampleTask(mock.Object))
      {
        await runner.Task_B();
        mock.Verify(x => x.DoSomething(), Times.Exactly(3));
      }
    }

    [TestMethod]
    public async Task CheckTaskC()
    {
      using (ExampleTask runner = new ExampleTask(mock.Object))
      {
        await runner.Task_C();
        mock.Verify(x => x.DoSomething(), Times.Exactly(2));
      }
    }

    [TestMethod]
    public async Task CheckTaskD()
    {
      using (ExampleTask runner = new ExampleTask(mock.Object))
      {
        await runner.Task_D();
        mock.Verify(x => x.DoSomething(), Times.Once);
      }
    }

    [TestMethod]
    public async Task CheckTaskE()
    {
      using (ExampleTask runner = new ExampleTask(mock.Object))
      {
        await runner.Task_E();
        mock.Verify(x => x.DoSomething(), Times.Once);
      }
    }
  }
}

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace challenge
{
  public class ExampleTask : IDisposable
  {
    private bool _disposedValue;
    private bool _lock = false;
    private ISimpleTask _simpleTask;

    public ExampleTask(ISimpleTask simpleTask)
    {
      this._simpleTask = simpleTask;
    }

    public async Task Task_A()
    {
      await Task.WhenAll(new[]
      {
        Task_B(),
        Task_C()
      });

      Trace.WriteLine("Task_A");
      await _simpleTask.DoSomething();
    }

    public async Task Task_B()
    {
      await Task.WhenAll(new[]
      {
        Task_D(),
        Task_E()
      });

      Trace.WriteLine("Task_B");
      await _simpleTask.DoSomething();
    }

    public async Task Task_C()
    {
      await Task_E();

      Trace.WriteLine("Task_C");
      await _simpleTask.DoSomething();
    }

    public async Task Task_D()
    {
      Trace.WriteLine("Task_D");
      await _simpleTask.DoSomething();
    }

    public async Task Task_E()
    {
      if (!_lock)
      {
        Trace.WriteLine("Task_E");
        await _simpleTask.DoSomething();
        _lock = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
      if (!_disposedValue)
      {
        if (disposing)
        {
          _lock = false;
        }
        _disposedValue = true;
      }
    }

  }
}

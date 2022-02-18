using System;
using System.Threading.Tasks;

namespace challenge
{
  public class SimpleTask: ISimpleTask
  {
    public async Task DoSomething(){
      await Task.Delay(new Random().Next(100, 500));
      throw new Exception("error");
    }
  }
}

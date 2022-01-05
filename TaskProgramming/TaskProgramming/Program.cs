using TaskProgramming;

// Introduction
var introducingTasks = new IntroducingTasks();
introducingTasks.CreateAndStartSimpleTasks();
introducingTasks.TasksWithState();
introducingTasks.TasksWithReturnValues();

// Cancelling tasks
var cancellingTasks = new CancellingTasks();
cancellingTasks.WaitingForTimeToPass();
cancellingTasks.CancellableTasks();
cancellingTasks.MonitoringCancellation();
cancellingTasks.CompositeCancellationToken();

// Exception handling
var exceptionHandling = new ExceptionHandling();
exceptionHandling.BasicHandling();

//      try
//      {
//        IterativeHandling();
//      }
//      catch (AggregateException ae)
//      {
//        Console.WriteLine("Some exceptions we didn't expect:");
//        foreach (var e in ae.InnerExceptions)
//          Console.WriteLine($" - {e.GetType()}");
//      }

// escalation policy (use Insert Signature CA)
TaskScheduler.UnobservedTaskException += (object? sender, UnobservedTaskExceptionEventArgs args) =>
{
    // this exception got handled
    args.SetObserved();

    var ae = args.Exception as AggregateException;
    ae?.Handle(ex =>
    {
        Console.WriteLine($"Policy handled {ex.GetType()}.");
        return true;
    });
};

exceptionHandling.IterativeHandling(); // throws
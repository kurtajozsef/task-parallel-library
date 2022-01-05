namespace TaskProgramming
{
    /// <summary>
    /// Introducing tasks class
    /// </summary>
    public class IntroducingTasks
    {
        /// <summary>
        /// Write s given character a thousand times in the console
        /// </summary>
        /// <param name="c">Character to be written</param>
        private void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }

        /// <summary>
        /// Write s given object a thousand times in the console
        /// </summary>
        /// <param name="s">Object to be written</param>
        private void Write(object s)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(s.ToString());
            }
        }

        /// <summary>
        /// Returns the length of the string representation of an object
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>Length of the o.ToString()</returns>
        private int TextLength(object o)
        {
            Console.WriteLine($"\nTask with id {Task.CurrentId} processing object '{o}'...");
            return o.ToString()!.Length;
        }

        /// <summary>
        /// Example of creating and starting simple tasks
        /// </summary>
        public void CreateAndStartSimpleTasks()
        {
            // a Task is a unit of work in .NET

            // here's how you make a simple task that does something
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Hello, Tasks!");
                Write('-');
            });

            // the argument is an action, so it can be a delegate, a lambda or an anonymous method

            Task t = new Task(() => Write('?'));
            t.Start(); // task doesn't start automatically!

            Write('.');
        }

        /// <summary>
        /// Example of tasks with return values
        /// </summary>
        public void TasksWithReturnValues()
        {
            string text1 = "testing", text2 = "this";
            var task1 = new Task<int>(TextLength!, text1);
            task1.Start();
            var task2 = Task.Factory.StartNew(TextLength!, text2);
            // getting the result is a blocking operation!
            Console.WriteLine($"Length of '{text1}' is {task1.Result}.");
            Console.WriteLine($"Length of '{text2}' is {task2.Result}.");
        }

        /// <summary>
        /// Example of tasks with state
        /// </summary>
        public void TasksWithState()
        {
            // clumsy 'object' approach
            Task t = new Task(Write!, "foo");
            t.Start();
            Task.Factory.StartNew(Write!, "bar");
        }

        // Summary:

        // 1. Two ways of using tasks
        //    Task.Factory.StartNew() creates and starts a Task
        //    new Task(() => { ... }) creates a task; use Start() to fire it
        // 2. Tasks take an optional 'object' argument
        //    Task.Factory.StartNew(x => { foo(x) }, arg);
        // 3. To return values, use Task<T> instead of Task
        //    To get the return value. use t.Result (this waits until task is complete)
        // 4. Use Task.CurrentId to identify individual tasks.
    }
}

using Task;

class Program
{
    static void Main()
    {
        var manager = new TaskManager();
        manager.LoadTasks();
        string userInput;
        int selectedTask = 0;
        bool exit = false;

        Console.WriteLine("Welcome To Miley Task Manager");
        Thread.Sleep(2000);
        Console.Clear();

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("MILEY TASK MANAGER\n\n");
            Console.WriteLine("1. View All Tasks\n2. Add A Task\n3.Complete A Task\n4. Delete Task\n5. Edit A Task\n6. Show Tasks By Filter\n7. Search Tasks\n8. Exit App");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    manager.ListTasks();
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter a task description below: ");
                    userInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.Clear();
                        manager.AddTask(userInput);
                        manager.SaveTask();
                        Console.WriteLine("New task added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Task not saved.");
                    }
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter task number below: ");
                    userInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out selectedTask))
                    {
                        manager.CompleteTask(selectedTask);
                        manager.SaveTask();
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input entered.");
                        Thread.Sleep(500);
                        break;
                    }
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter task number below: ");
                    userInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out selectedTask))
                    {
                        manager.DeleteTask(selectedTask);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input entered");
                        Thread.Sleep(700);
                        break;
                    }
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Enter task number below: ");
                    userInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out selectedTask))
                    {
                        Console.WriteLine("Enter new description: ");
                        userInput = Console.ReadLine();
                        if (userInput != null)
                        {
                            string newDescription = userInput;
                            manager.EditTask(selectedTask, newDescription);
                            manager.SaveTask();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid task number entered");
                    }
                    Console.ReadLine();
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("Enter an option:\n1. View completed tasks \n2. View incomplete tasks");
                    userInput = Console.ReadLine();
                    int option;
                    if (int.TryParse(userInput, out option))
                    {
                        switch (option)
                        {
                            case 1:
                                manager.FilterTasks(true);
                                break;
                            case 2:
                                manager.FilterTasks(false);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option entered");
                    }
                    Console.ReadLine();
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("Enter search term: ");
                    userInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine("No search term entered");
                    }
                    else
                    {
                        manager.SearchTask(userInput);
                    }
                    Console.ReadLine();
                    break;

                case "8":
                    Console.WriteLine("Exiting App..");
                    exit = true;
                    break;
            }
        }
    }
}
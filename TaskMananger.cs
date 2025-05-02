namespace Task;
using System.Text.Json;

public class TaskManager
{
    private List<TaskItem> _tasks;
    private string _filePath;

    public TaskManager(string filePath = "tasks.json")
    {
        _filePath = filePath;
        _tasks = File.Exists(_filePath) ? JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(_filePath)) : new List<TaskItem>();
    }

    public void LoadTasks()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            _tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
    }

    public void SaveTask()
    {
        var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public void AddTask(string description)
    {
        int id = _tasks.Count > 0 ? _tasks.Max(t => t.TaskId) + 1 : 1;
        _tasks.Add(new TaskItem { TaskId = id, Description = description, Completed = false });
    }

    public void ListTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("No tasks currently available.");
            return;
        }
        foreach (var task in _tasks)
        {
            Console.WriteLine(task);
        }
    }

    public void CompleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.TaskId == id);
        if (task != null)
        {
            task.Completed = true;
            Console.WriteLine($"Task {id} marked completed.");
        }
        else
        {
            Console.WriteLine("Invalid task number, try again");
        }
    }

    public void DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.TaskId == id);
        if (task != null)
        {
            _tasks.Remove(task);
            Console.WriteLine("Task successfully deleted");
        }
        else
        {
            Console.WriteLine($"Task number {id} does not exist in the current task list");
        }
    }

    public void EditTask(int id, string newDescription)
    {
        var task = _tasks.FirstOrDefault(t => t.TaskId == id);
        if (task != null)
        {
            task.Description = newDescription;
            Console.WriteLine("Task updated");
        }
        else
        {
            Console.WriteLine("Invalid input entered");
        }
    }

    public void FilterTasks(bool completeTasks)
    {
        var checkedTask = _tasks.Where(t => t.Completed == true).ToList();
        var uncheckedTask = _tasks.Where(t => t.Completed == false).ToList();

        if (!completeTasks)
        {
            if (uncheckedTask.Count == 0)
            {
                Console.WriteLine("All tasks are completed!");
            }
            foreach (var task in uncheckedTask)
            {
                if (task != null)
                {
                    Console.WriteLine(task);
                }
            }
        }
        if (completeTasks == true)
        {
            if (checkedTask.Count() == 0)
            {
                Console.WriteLine("Oops you haven't completed any task");
            }
            foreach (var task in checkedTask)
            {
                if (task != null)
                {
                    Console.WriteLine(task);
                }
            }
        }
    }

    public void SearchTask(string input)
    {
        var task = _tasks.Where(t => t.Description.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
        if (task != null)
        {
            foreach (var item in task)
            {
                Console.WriteLine(item);
            }
        }
    }
}
using Task;

public class TaskItem
{
    public int TaskId { get; set;}
    public string Description {get; set;}
    public bool Completed { get; set;}

    public override string ToString()
    {
        return $"{TaskId}-\t{(Completed? "X" : "#")} - {Description}";
    }
}
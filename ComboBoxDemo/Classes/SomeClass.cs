namespace ComboBoxDemo.Classes;
internal class SomeClass
{
    public delegate void OnCondition(bool condition);
    public static event OnCondition Condition;

    public static void CostSql()
    {
        Condition?.Invoke(DateTime.Now.DayOfWeek is not 
            (DayOfWeek.Sunday or DayOfWeek.Saturday));
    }
}


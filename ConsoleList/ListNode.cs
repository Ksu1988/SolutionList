namespace ConsoleList
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public ListNode<T> NextNode { get; set; }
    }
}


namespace FordFulkerson.Map
{
    public class NodeTree<T, V>
    {
        public V Item;
        public T Key;
        public int Height;
        public NodeTree<T, V> Left;
        public NodeTree<T, V> Right;

        public NodeTree(T key, V value)
        {
            Key = key;
            Left = Right = null;
            Height = 1;
            Item = value;
        }
    }
}

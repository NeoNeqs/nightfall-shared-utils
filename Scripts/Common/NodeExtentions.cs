using Godot;

using SharedUtils.Exception;

namespace SharedUtils.Common
{
    public static class NodeExtentions
    {
        public static T GetNodeD<T>(this Node instance, NodePath path) where T : Node
        {
            Node node = instance.GetNodeOrNull<T>(path);
#if DEBUG
            if (node == null)
            {
                throw new NodeNotFoundException(path);
            }
#endif
            return (T)node;
        }

        public static Node GetNodeD(this Node instance, NodePath path)
        {
            Node node = instance.GetNodeOrNull(path);
#if DEBUG
            if (node == null)
            {
                throw new NodeNotFoundException(path);
            }
#endif
            return node;
        }
    }
}

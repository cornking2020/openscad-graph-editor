using Godot;
using GodotExt;
using Serilog;

namespace OpenScadGraphEditor.Widgets
{
    /// <summary>
    /// Super simple notification service to show a notification from everywhere. Not sure if i like this "design"
    /// but it is the simplest solution that works.
    /// </summary>
    public class NotificationService : Node
    {
        private static NotificationService _instance;

        public override void _Ready()
        {
            _instance = this;
        }
        
        public static void ShowNotification(string message)
        {
            Log.Information("Notification: {Message}", message);
            var bubble = NotificationBubble.NotificationBubble.Create(message, false);
            bubble.MoveToNewParent(_instance);
        }

        public static void ShowError(string message)
        {
            Log.Information("Error notification: {Message}", message);
            var bubble = NotificationBubble.NotificationBubble.Create(message, true);
            bubble.MoveToNewParent(_instance);
        }
    }
}
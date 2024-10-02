namespace RemoteControl
{
    static class RemoteControl
    {
        static void Main()
        {
            SimpleRemoteControl remote = new SimpleRemoteControl();
            remote.SetCommand(new LightOnCommand(new Light()));
            remote.ButtonWasPressed();

            Console.ReadLine();

            remote.SetCommand(new GarageDoorOpenCommand(new GarageDoor()));
            remote.ButtonWasPressed();

            Console.ReadLine();

        }
    }

    interface Command
    {
        public void Execute();
    }

    class Light
    {
        public void On()
        {
            Console.WriteLine("Light is on.");
        }
    }

    class LightOnCommand : Command
    {
        Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.On();
        }
    }

    class GarageDoor
    {
        public void Open()
        {
            Console.WriteLine("Garge door is open.");
        }
    }
    class GarageDoorOpenCommand : Command
    {
        GarageDoor garageDoor;
        public GarageDoorOpenCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }
        public void Execute()
        {
           garageDoor.Open(); 
        }
    }

    class SimpleRemoteControl
    {
        Command? slot;

        public void SetCommand(Command cmd) 
        {
            slot = cmd;
        }

        public void ButtonWasPressed()
        {
            slot.Execute();
        }
    }
}
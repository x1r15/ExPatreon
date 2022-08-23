namespace GameInput
{
    public partial class InputActions
    {
        private static InputActions _instance;

        public static InputActions Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InputActions();
                    _instance.Enable();
                }

                return _instance;
            }
            private set => _instance = value;
        }
    }
}

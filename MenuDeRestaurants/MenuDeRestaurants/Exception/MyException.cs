namespace MenuDeRestaurants.Exception
{
    public class MyException : System.Exception
    {
        public MyException() { }

        public MyException(string name)
            : base($"Not Found item: {name}")
        {

        }
    }
}
